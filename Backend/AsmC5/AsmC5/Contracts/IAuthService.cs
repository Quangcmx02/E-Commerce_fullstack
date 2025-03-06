using AsmC5.DTOs.AuthDtos;
using AsmC5.DTOs.TokenDtos;
using AsmC5.DTOs.UserDtos;
using AsmC5.Models;

namespace AsmC5.Contracts
{
    public interface IAuthService
    {
        Task<bool> CheckUsernameAvailabilityAsync(string username);
        Task<(UserDto adminDto, TokenDto tokenDto)> LoginAdminAsync(SignInDto loginDto);
        Task<bool> CheckEmailAvailabilityAsync(string email);
        Task RegisterUserAsync(SignUpDto registrationDto);
        Task<(UserDto userDto, TokenDto tokenDto)> LoginAsync(SignInDto loginDto);
        Task ChangePasswordAsync(ChangePasswordDto changePasswordDto);
        Task<TokenDto> RefreshTokenAsync(TokenDto tokenDto);
        Task<TokenDto> GenerateAndAssignTokensAsync(ApplicationUser user);
        Task<(UserDto userDto, TokenDto tokenDto)> LoginWithGoogleAsync(string credential);
    }
}
