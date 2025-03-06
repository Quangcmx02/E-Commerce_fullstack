using AsmC5.Common.Request;
using AsmC5.DTOs.AuthDtos;
using AsmC5.DTOs.UserDtos;
using AsmC5.Models;
using System.Security.Claims;

namespace AsmC5.Contracts
{
    public interface IUserService
    {
        Task UpdateUserForAdminAsync(string userId, UserUpdateForAdmin userForUpdateDto);
        Task<UserDto> GetUserByIdAsync(string userId);
        Task<UserDto> CreateUserAsync(SignUpDto userForCreateDto);
        Task DeleteUserAsync(string userId);
        Task<UserDto> GetUserByEmailAsync(string email);
        Task ChangePasswordAsync(string userId, ChangePasswordDto changePasswordDto);
        Task<UserDto> GetCurrentUserAsync(ClaimsPrincipal user);
        Task<(IEnumerable<UserDto> userDtos, MetaData metaData)> GetUsersAsync(
            UserRequestParameters userRequestParameters);
        Task<UserDto> UpdateCurrentUserAsync(ClaimsPrincipal userClaim, UpdateProfileDto userForUpdateDto);
    }
}
