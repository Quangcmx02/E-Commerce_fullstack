using System.IdentityModel.Tokens.Jwt;
using AsmC5.Common.Models;
using AsmC5.DTOs.AuthDtos;
using AsmC5.DTOs.TokenDtos;
using AsmC5.DTOs.UserDtos;
using AsmC5.Interfaces;
using AsmC5.Models;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.SqlServer.Server;
using Newtonsoft.Json;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;
using System.Text;
using AsmC5.Contracts;
using Google.Apis.Auth;
using System.IdentityModel.Tokens.Jwt;
namespace AsmC5.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration _configuration;
        private readonly GoogleAuthSettings _googleSettings;
        private readonly ILoggerService _logger;
        private ApplicationUser _user;

        public AuthService(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILoggerService logger,
            IConfiguration configuration,
            IOptions<GoogleAuthSettings> googleSettings)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
            _googleSettings = googleSettings.Value;

        }
        public async Task<(UserDto adminDto, TokenDto tokenDto)> LoginAdminAsync(SignInDto loginDto)
        {
            try
            {
       
                var admin = await _userManager.FindByEmailAsync(loginDto.Email) ;

                if (admin == null)
                {
                    _logger.LogError("Không tìm thấy thông tin người dùng.");
                    throw new Exception("Tài khoản không tồn tại trong hệ thống.");
                }

                var result = await _signInManager.PasswordSignInAsync(
                    admin.UserName!,
                    loginDto.Password,
                    loginDto.IsRemember,
                    lockoutOnFailure: false
                );

                if (!result.Succeeded)
                {
                    _logger.LogError("Đăng nhập thất bại - Sai mật khẩu.");
                    throw new Exception("Tên đăng nhập hoặc mật khẩu không chính xác.");
                }

                if (!await _userManager.IsInRoleAsync(admin, "Admin"))
                {
                    _logger.LogError("Đăng nhập thất bại - Không có quyền truy cập.");
                    throw new Exception("Tài khoản không có quyền truy cập.");
                }

                var adminDto = _mapper.Map<UserDto>(admin);
                adminDto.Roles = await _userManager.GetRolesAsync(admin);

                var tokenDto = await GenerateAndAssignTokensAsync(admin);

                _logger.LogInfo($"Người dùng {admin.UserName} đăng nhập thành công");

       
                return (adminDto, tokenDto);

            }
            catch (Exception)
            {
                _logger.LogError("Không thể đăng nhập");
                await _unitOfWork.RollbackAsync();
                throw;
            }
        }

      public async Task<(UserDto userDto, TokenDto tokenDto)> LoginWithGoogleAsync(string credential)
{
    try
    {
        // ✅ Giải mã JWT Token
        var handler = new JwtSecurityTokenHandler();
        var token = handler.ReadJwtToken(credential);
        foreach (var claim in token.Claims)
        {
            Console.WriteLine($"Claim Type: {claim.Type}, Value: {claim.Value}");
        }

        var googleUser = new GoogleUserInfo
        {
            Email = token.Claims.FirstOrDefault(c => c.Type == "email")?.Value,  // Đổi ClaimTypes.Email thành "email"
            Picture = token.Claims.FirstOrDefault(c => c.Type == "picture")?.Value,
            EmailVerified = bool.Parse(token.Claims.FirstOrDefault(c => c.Type == "email_verified")?.Value ?? "false"),
            Given_Name = token.Claims.FirstOrDefault(c => c.Type == "given_name")?.Value,
            Family_Name = token.Claims.FirstOrDefault(c => c.Type == "family_name")?.Value
        };


                if (string.IsNullOrEmpty(googleUser.Email))
        {
            throw new Exception("Không lấy được email từ Google.");
        }

        // ✅ Kiểm tra user có tồn tại chưa
        var user = await _userManager.FindByEmailAsync(googleUser.Email);

        if (user == null)
        {
            user = new ApplicationUser
            {
                Email = googleUser.Email,
                UserName = googleUser.Email,
                PhotoUrl = googleUser.Picture,
                EmailConfirmed = googleUser.EmailVerified,
                FirstName = googleUser.Given_Name,
                LastName = googleUser.Family_Name,
                PasswordHash = Guid.NewGuid().ToString(),
            };

            var result = await _userManager.CreateAsync(user);
            if (!result.Succeeded)
            {
                _logger.LogError($"Không thể tạo tài khoản Google cho user: {user.Email}");
                throw new Exception("Không thể tạo tài khoản Google.");
            }

            await _userManager.AddToRoleAsync(user, "user");
        }

        var userDto = _mapper.Map<UserDto>(user);
        userDto.Roles = await _userManager.GetRolesAsync(user);

        var tokenDto = await GenerateAndAssignTokensAsync(user);

        _logger.LogInfo($"Đăng nhập Google thành công: {user.Email}");

        return (userDto, tokenDto);
    }
    catch (SecurityTokenException)
    {
        _logger.LogError("Token Google không hợp lệ");
        throw new Exception("Token Google không hợp lệ");
    }
    catch (Exception ex)
    {
        _logger.LogError($"Lỗi đăng nhập Google: {ex.Message}");
        throw;
    }
}

        public async Task<bool> CheckUsernameAvailabilityAsync(string username)
        {
            var user = await _userManager.FindByNameAsync(username);
            return user == null;
        }

        public async Task<bool> CheckEmailAvailabilityAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            return user == null;
        }
        public async Task RegisterUserAsync(SignUpDto registrationDto)
        {
            try
            {
                await _unitOfWork.BeginTransactionAsync();

                bool isEmailExist = !await CheckEmailAvailabilityAsync(registrationDto.Email);
                if (isEmailExist)
                {
                    _logger.LogError($"Email {registrationDto.Email} đã tồn tại trong hệ thống.");
                    throw new Exception($"Email {registrationDto.Email} đã tồn tại trong hệ thống.");
                }

                bool isUsernameExist = !await CheckUsernameAvailabilityAsync(registrationDto.Username);
                if (isUsernameExist)
                {
                    _logger.LogError($"Username {registrationDto.Username} đã tồn tại trong hệ thống.");
                    throw new Exception($"Username {registrationDto.Username} đã tồn tại trong hệ thống.");
                }

                var user = _mapper.Map<ApplicationUser>(registrationDto);
                var result = await _userManager.CreateAsync(user, registrationDto.Password);

                if (!result.Succeeded)
                {
                    _logger.LogError("Đăng ký tài khoản thất bại.");
                    throw new Exception("Đăng ký tài khoản thất bại.");
                }
                var roles = new List<string> { "User" };
                var roleResult = await _userManager.AddToRolesAsync(user, roles);

                if (!roleResult.Succeeded)
                {
                    _logger.LogError("Gán vai trò cho tài khoản thất bại.");
                    throw new Exception("Gán vai trò cho tài khoản thất bại.");
                }
                await _unitOfWork.SaveChangesAsync();
                await _unitOfWork.CommitAsync();

                _logger.LogInfo($"Tạo tài khoản mới thành công cho user {user.UserName}");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Đã xảy ra lỗi khi đăng ký tài khoản: {ex.Message}");
                await _unitOfWork.RollbackAsync();
                throw;
            }
        }

        public async Task<(UserDto userDto, TokenDto tokenDto)> LoginAsync(SignInDto loginDto)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(loginDto.Email);

                if (user == null)
                {
                    _logger.LogError("Không tìm thấy thông tin người dùng.");
                    throw new Exception("Tài khoản không tồn tại trong hệ thống.");
                }

                var result = await _signInManager.PasswordSignInAsync(
                    user.UserName!,
                    loginDto.Password,
                    loginDto.IsRemember,
                    lockoutOnFailure: false
                );

                if (!result.Succeeded)
                {
                    _logger.LogError("Đăng nhập thất bại - Sai mật khẩu.");
                    throw new Exception("Tên đăng nhập hoặc mật khẩu không chính xác.");
                }


                var userDto = _mapper.Map<UserDto>(user);
                userDto.Roles = await _userManager.GetRolesAsync(user);

                var tokenDto = await GenerateAndAssignTokensAsync(user);

                _logger.LogInfo($"Người dùng {user.UserName} đăng nhập thành công");

                return (userDto, tokenDto);
            }
            catch (Exception)
            {
                _logger.LogError("Không thể đăng nhập");
                throw;
            }
        }
        public async Task ChangePasswordAsync(ChangePasswordDto changePasswordDto)
        {
            try
            {
                await _unitOfWork.BeginTransactionAsync();

                var user = await _userManager.FindByNameAsync(changePasswordDto.UserName);
                if (user == null)
                {
                    _logger.LogError($"Không tìm thấy user {changePasswordDto.UserName}");
                    throw new Exception($"Không tìm thấy tài khoản {changePasswordDto.UserName}");
                }

                if (changePasswordDto.CurrentPassword == changePasswordDto.NewPassword)
                {
                    _logger.LogError("Mật khẩu mới phải khác mật khẩu hiện tại");
                    throw new Exception("Mật khẩu mới phải khác mật khẩu hiện tại");
                }

                var result = await _userManager.ChangePasswordAsync(
                    user,
                    changePasswordDto.CurrentPassword,
                    changePasswordDto.NewPassword
                );

                if (!result.Succeeded)
                {
                    _logger.LogError("Đổi mật khẩu thất bại");
                    throw new Exception("Đổi mật khẩu thất bại");
                }

                await _unitOfWork.SaveChangesAsync();
                await _unitOfWork.CommitAsync();

                _logger.LogInfo($"Đổi mật khẩu thành công cho user {user.UserName}");
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackAsync();
                throw;
            }
        }


        public async Task<TokenDto> GenerateAndAssignTokensAsync(ApplicationUser user)
        {
            return await GenerateTokensForUserAsync(user, true);
        }
        private async Task<TokenDto> GenerateTokensForUserAsync(ApplicationUser user, bool updateRefreshToken)
	{
		var signingCredentials = GetSigningCredentials();
		var claims = await GetClaimsForUserAsync(user);
		var tokenOptions = GenerateTokenOptions(signingCredentials, claims);
		var accessToken = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
		var refreshToken = user.RefreshToken;

		if (updateRefreshToken)
		{
			refreshToken = GenerateRefreshToken();
			var jwtSettings = _configuration.GetSection("JwtSettings");
			var expires = DateTimeOffset.Now.AddDays(40);

            Console.WriteLine($"Expires Refresh Token: {expires.UtcDateTime}");
            Console.WriteLine($"Current Time UTC Now: {DateTime.UtcNow}");
			Console.WriteLine($"Current Time Now: {DateTime.Now}");
			user.RefreshToken = refreshToken;
			user.RefreshTokenExpiryTime = expires.UtcDateTime;
			await _userManager.UpdateAsync(user);
			await _unitOfWork.SaveChangesAsync();
		}

		return new TokenDto
		{
			AccessToken = accessToken,
			RefreshToken = user.RefreshToken!
		};
	}
        private async Task<List<Claim>> GetClaimsForUserAsync(ApplicationUser user)
        {
            var claimsBuilder = new ClaimsBuilder(user)
                .AddUsername()
                .AddEmail()
                .AddUserId()
                .AddFirstname()
                .AddLastname();

            await claimsBuilder.AddRolesAsync(_userManager);
            return claimsBuilder.Build();
        }
        private async Task<TokenDto> GenerateTokensAsync(bool updateRefreshToken)
        {
            var signingCredentials = GetSigningCredentials();
            var claims = await GetClaimsAsync();
            var tokenOptions = GenerateTokenOptions(signingCredentials, claims);
            var accessToken = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
            var refreshToken = _user.RefreshToken;

            if (updateRefreshToken)
            {
                refreshToken = GenerateRefreshToken();
                var jwtSettings = _configuration.GetSection("JwtSettings");
                var expires = DateTimeOffset.Now.AddDays(Convert.ToDouble(jwtSettings["RefreshTokenExpiryDays"]));

                _user.RefreshToken = refreshToken;
                _user.RefreshTokenExpiryTime = expires.UtcDateTime;
                await _userManager.UpdateAsync(_user);
            }

            var token = new TokenDto
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken
            };

            return token;
        }

        private SigningCredentials GetSigningCredentials()
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");
            var key = Encoding.UTF8.GetBytes(jwtSettings["SecurityKey"]!);
            var secret = new SymmetricSecurityKey(key);

            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }

        private async Task<List<Claim>> GetClaimsAsync()
        {
            var claimsBuilder = new ClaimsBuilder(_user)
            .AddUsername()
            .AddEmail()
            .AddUserId()
            .AddFirstname()
            .AddLastname();

            await claimsBuilder.AddRolesAsync(_userManager);

            return claimsBuilder.Build();
        }

        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");
            var now = DateTimeOffset.Now;
            var expires = now.AddMinutes(Convert.ToDouble(jwtSettings["TokenExpiryMinutes"]));
            var tokenOptions = new JwtSecurityToken
            (
                issuer: jwtSettings["ValidIssuer"],
                audience: jwtSettings["ValidAudience"],
                claims: claims,
                notBefore: now.UtcDateTime,
                expires: expires.UtcDateTime,
                signingCredentials: signingCredentials
            );
            return tokenOptions;
        }

        private ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = true,
                ValidateIssuer = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(jwtSettings["SecurityKey"]!)),
                ValidateLifetime = false,
                ValidIssuer = jwtSettings["ValidIssuer"],
                ValidAudience = jwtSettings["ValidAudience"]
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken;
            ClaimsPrincipal principal;

            try
            {
                principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out securityToken);
            }
            catch (Exception)
            {
                throw new SecurityTokenException("Invalid token");
            }

            var jwtSecurityToken = securityToken as JwtSecurityToken;
            if (jwtSecurityToken == null ||
                !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256,
                    StringComparison.InvariantCultureIgnoreCase))
            {
                throw new SecurityTokenException("Invalid token");
            }

            return principal;
        }



        public async Task<TokenDto> RefreshTokenAsync(TokenDto tokenDto)
        {
            var principal = GetPrincipalFromExpiredToken(tokenDto.AccessToken);
            var userId = principal.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(userId))
            {
                throw new Exception("Không thể tìm thấy ID người dùng từ token đã hết hạn.");
            }

            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                throw new Exception("Người dùng không tồn tại.");
            }

            if (user.RefreshToken != tokenDto.RefreshToken)
            {
                throw new Exception("Refresh Token không khớp.");
            }

            if (user.RefreshTokenExpiryTime <= DateTimeOffset.UtcNow)
            {
                throw new Exception("Refresh Token đã hết hạn.");
            }

            _user = user;
            // Không cập nhật refresh token nếu nó chưa hết hạn
            return await GenerateTokensAsync(updateRefreshToken: false);
        }

        private string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }
    }
}
