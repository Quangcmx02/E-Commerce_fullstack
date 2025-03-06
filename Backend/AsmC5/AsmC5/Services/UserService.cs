using AsmC5.Common.Request;
using AsmC5.Contracts;
using AsmC5.DTOs.AuthDtos;
using AsmC5.DTOs.UserDtos;
using AsmC5.Exceptions.NotFound;
using AsmC5.Interfaces;
using AsmC5.Models;
using AsmC5.Persistence.Repositories;
using AutoMapper;
using ManboShopAPI.Domain.Exceptions.BadRequest;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System.Security.Claims;

namespace AsmC5.Services
{
    public class UserService : IUserService
    {
        private readonly ICartRepository _cartRepository;
        private readonly IUserRepository _userRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        private readonly ILoggerService _logger;
        private readonly RoleManager<IdentityRole> _roleManager;
        public UserService(
        
            IUserRepository userRepository,
            ICartRepository cartRepository,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            ILoggerService logger,
            IMapper mapper)
        {
            _userRepository = userRepository;
            _cartRepository = cartRepository;
            _userManager = userManager;
            _mapper = mapper;
            _logger = logger;
            _roleManager = roleManager;
     
        }
        public async Task<UserDto> GetUserByIdAsync(string userId)
        {
            var user = await _userRepository.GetUserByIdAsync(userId);
            if (user == null)
            {
                _logger.LogError($"Không tìm thấy người dùng với id {userId}");
                throw new UserNotFoundException(userId);
            }

            _logger.LogInfo($"Lấy dữ liệu người dùng thành công.");
            return _mapper.Map<UserDto>(user);
        }
        public async Task<UserDto> GetUserByEmailAsync(string email)
        {
            var user = await _userRepository.GetUserByEmailAsync(email);
            if (user == null)
            {
                _logger.LogError($"Không tìm thấy người dùng với email {email}");
                throw new UserNotFoundException($"Không tìm thấy người dùng với email {email}");
            }

            _logger.LogInfo($"Lấy dữ liệu người dùng thành công.");
            return _mapper.Map<UserDto>(user);
        }
        public async Task<UserDto> CreateUserAsync(SignUpDto userForCreateDto)
        {
            if (await _userRepository.EmailExistsAsync(userForCreateDto.Email))
            {
                _logger.LogError($"Email {userForCreateDto.Email} đã tồn tại trong hệ thống.");
                throw new UserBadRequestException($"Email {userForCreateDto.Email} đã tồn tại trong hệ thống.");
            }

            if (await _userRepository.UserNameExistsAsync(userForCreateDto.Username))
            {
                _logger.LogError($"Tên đăng nhập {userForCreateDto.Username} đã tồn tại trong hệ thống.");
                throw new UserBadRequestException($"Tên đăng nhập {userForCreateDto.Username} đã tồn tại trong hệ thống.");
            }

            var rolesInDb = await _roleManager.Roles.Select(r => r.Name).ToListAsync();

            if (userForCreateDto.Roles.Any(role => !rolesInDb.Contains(role)))
            {
                _logger.LogError("Roles chứa giá trị không hợp lệ.");
                throw new UserBadRequestException($"Roles chứa giá trị không hợp lệ. Chỉ chấp nhận {string.Join(", ", rolesInDb)}.");
            }

            var user = _mapper.Map<ApplicationUser>(userForCreateDto);

            var passwordHasher = new PasswordHasher<ApplicationUser>();
            var passwordValidator = new PasswordValidator<ApplicationUser>();

            var passwordValidationResult = await passwordValidator.ValidateAsync(_userManager, user, userForCreateDto.Password);
            if (!passwordValidationResult.Succeeded)
            {
                var errors = string.Join(", ", passwordValidationResult.Errors.Select(e => e.Description));
                _logger.LogError($"Mật khẩu không đáp ứng yêu cầu: {errors}");
                throw new UserBadRequestException($"Mật khẩu không đáp ứng yêu cầu: {errors}");
            }
            user.PasswordHash = passwordHasher.HashPassword(user, userForCreateDto.Password);

            var result = await _userManager.CreateAsync(user, userForCreateDto.Password);

            if (!result.Succeeded)
            {
                var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                _logger.LogError($"Tạo người dùng thất bại: {errors}");
                throw new UserBadRequestException($"Tạo người dùng thất bại: {errors}");
            }

            foreach (var role in userForCreateDto.Roles)
            {
                await _userManager.AddToRoleAsync(user, role);
            }
            _logger.LogInfo("Tạo người dùng mới thành công.");

            return _mapper.Map<UserDto>(user);
        }
        public async Task DeleteUserAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                _logger.LogError($"Không tìm thấy người dùng với ID {userId}");
                throw new UserNotFoundException(userId);
            }

            _userRepository.Remove(user);
            await _userRepository.SaveChangesAsync();

        
        }
        public async Task UpdateUserForAdminAsync(string userId, UserUpdateForAdmin userForUpdateDto)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                _logger.LogError($"Không tìm thấy người dùng với ID {userId}");
                throw new UserNotFoundException(userId);
            }

            // Kiểm tra nếu Email đã tồn tại
            if (await _userRepository.EmailExistsAsync(userForUpdateDto.Email) && user.Email != userForUpdateDto.Email)
            {
                _logger.LogError($"Email đã tồn tại");
                throw new UserNotFoundException($"Email {userForUpdateDto.Email} đã tồn tại trong hệ thống.");
            }

            // Cập nhật thông tin người dùng (trừ vai trò)
            _mapper.Map(userForUpdateDto, user);
            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                _logger.LogError($"Cập nhật người dùng thất bại: {errors}");
                throw new UserBadRequestException($"Cập nhật người dùng thất bại: {errors}");
            }

            // Kiểm tra nếu người dùng hiện tại có vai trò Admin
            var userRoles = await _userManager.GetRolesAsync(user);
            if (userRoles.Contains("Admin"))
            {
                _logger.LogWarning("Không thể thay đổi vai trò của Admin.");
                return; // Không cập nhật vai trò nếu là Admin
            }

            // Nếu có danh sách vai trò mới, kiểm tra hợp lệ và cập nhật
            if (userForUpdateDto.Roles != null)
            {
                var rolesInDb = await _roleManager.Roles.Select(r => r.Name).ToListAsync();
                if (userForUpdateDto.Roles.Any(role => !rolesInDb.Contains(role)))
                {
                    throw new UserBadRequestException($"Roles chứa giá trị không hợp lệ. Chỉ chấp nhận {string.Join(", ", rolesInDb)}.");
                }

                await _userManager.RemoveFromRolesAsync(user, userRoles);
                foreach (var role in userForUpdateDto.Roles)
                {
                    await _userManager.AddToRoleAsync(user, role);
                }
            }

            await _userRepository.SaveChangesAsync();
        }

        public async Task<UserDto> UpdateCurrentUserAsync(ClaimsPrincipal userClaim, UpdateProfileDto userForUpdateDto)
        {

            var userId = userClaim.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))
            {
                _logger.LogError("Không tìm thấy ID người dùng trong claim");
                throw new ArgumentException("ID người dùng không hợp lệ");
            }
            var user = await _userRepository.GetUserByIdAsync(userId);

            if (user == null)
            {
                _logger.LogError($"Không tìm thấy người dùng với ID {userId}");
                throw new UserNotFoundException(userId);
            }

            // Cập nhật thông tin cá nhân
            user.FirstName = userForUpdateDto.FirstName ?? user.FirstName;
            user.LastName = userForUpdateDto.LastName ?? user.LastName;
            user.PhotoUrl = userForUpdateDto.PhotoUrl ?? user.PhotoUrl;
            user.PhoneNumber = userForUpdateDto.PhoneNumber ?? user.PhoneNumber;
          

            var updateResult = await _userManager.UpdateAsync(user);
            if (!updateResult.Succeeded)
            {
                var errors = string.Join(", ", updateResult.Errors.Select(e => e.Description));
                _logger.LogError($"Cập nhật người dùng thất bại: {errors}");
                throw new UserBadRequestException($"Cập nhật người dùng thất bại: {errors}");
            }

            _logger.LogInfo("Cập nhật người dùng thành công.");

            return _mapper.Map<UserDto>(user);
        }
        public async Task<(IEnumerable<UserDto> userDtos, MetaData metaData)> GetUsersAsync(UserRequestParameters userRequestParameters)
        {
            var users = await _userRepository.FetchAllUserAsync(userRequestParameters);
            _logger.LogInfo("Lấy danh sách người dùng thành công.");
            var userDtoList = _mapper.Map<IEnumerable<UserDto>>(users);

            // Lấy danh sách Role cho từng User
            foreach (var userDto in userDtoList)
            {
                var user = users.FirstOrDefault(u => u.Id == userDto.Id);
                if (user != null)
                {
                    var roles = await _userManager.GetRolesAsync(user);
                    userDto.Roles = roles.ToList();
                }
            }

            return (userDtoList, users.MetaData);
        }
        public async Task ChangePasswordAsync(string userId, ChangePasswordDto changePasswordDto)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null)
            {
                _logger.LogError($"Không tìm thấy người dùng với Id {userId}");
                throw new UserNotFoundException(userId);
            }

            var result = await _userManager.ChangePasswordAsync(
                user,
                changePasswordDto.CurrentPassword,
                changePasswordDto.NewPassword
            );

            if (!result.Succeeded)
            {
                var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                _logger.LogError($"Thay đổi mật khẩu thất bại: {errors}");
                throw new UserBadRequestException($"Thay đổi mật khẩu thất bại: {errors}");
            }

            _logger.LogInfo($"Thay đổi mật khẩu thành công cho người dùng với Id {userId}");
        }
        public async Task<UserDto> GetCurrentUserAsync(ClaimsPrincipal user)
        {
            // Extract user ID from access token
            var userId = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))
            {
                _logger.LogError("Không tìm thấy thông tin người dùng từ token.");
                throw new UnauthorizedAccessException("Không có thông tin xác thực.");
            }


           


            var userCurrent = await _userRepository
                .FindByCondition(u => u.Id == userId)
               
                .FirstOrDefaultAsync();
            if (userCurrent == null)
            {
                _logger.LogError($"Không tìm thấy người dùng với ID {userId}");
                throw new UserNotFoundException(userId);
            }
            var totallCartProducts = await _cartRepository.GetTotalCartProductsForUser(userId);

            var userDto = _mapper.Map<UserDto>(userCurrent);
            var roles = await _userManager.GetRolesAsync(userCurrent);
            userDto.Roles = roles;
        
            userDto.TotalCartProducts = totallCartProducts;

            _logger.LogInfo("Lấy thông tin người dùng hiện tại thành công.");
            return userDto;
        }
    }
}
