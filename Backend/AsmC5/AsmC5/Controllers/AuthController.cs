using AsmC5.Common.Response;
using AsmC5.Contracts;
using AsmC5.DTOs.TokenDtos;
using AsmC5.DTOs.UserDtos;
using Microsoft.AspNetCore.Mvc;
using NuGet.Common;
using System.Net.Mime;
using AsmC5.DTOs.AuthDtos;
using AsmC5.Fillters;
using Token = AsmC5.Common.Response.Token;

namespace AsmC5.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService) =>
            _authService = authService;

        [HttpPost("check-username/{username}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<bool>> CheckUsername(string username)
        {
            var isAvailable = await _authService.CheckUsernameAvailabilityAsync(username);
            return Ok(new ApiResponse<object>
            {
                StatusCode = 200,
                Success = true,
                Data = isAvailable,
                Message = "Kiểm tra username thành công."
            });
        }
        [HttpPost("check-email/{email}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<bool>> CheckEmail(string email)
        {
            var isAvailable = await _authService.CheckEmailAvailabilityAsync(email);
            return Ok(new ApiResponse<object>
            {
                StatusCode = 200,
                Success = true,
                Data = isAvailable,
                Message = "Kiểm tra email thành công."
            });
        }

        [HttpPost("register")]
        [ValidationFilter]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Register([FromBody] SignUpDto registrationDto)
        {
            await _authService.RegisterUserAsync(registrationDto);
            return StatusCode(201, new ApiResponse<object>
            {
                StatusCode = 201,
                Success = true,
                Message = "Đăng ký tài khoản thành công."
            });
        }

        [HttpPost("login")]
        [ValidationFilter]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<(UserDto, TokenDto)>> Login([FromBody] SignInDto loginDto)
        {
            var (userDto, tokenDto) = await _authService.LoginAsync(loginDto);
            var token = new Token
            {
                AccessToken = tokenDto.AccessToken,
                RefreshToken = tokenDto.RefreshToken
            };
            return Ok(new ApiResponse<object>
            {
                StatusCode = 200,
                Success = true,
                Message = "Đăng nhập thành công.",
                Data = new { User = userDto },
                Token = token
            });
        }

        [HttpPost("admin-login")]
        [ValidationFilter]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<(UserDto, TokenDto)>> AdminLogin([FromBody] SignInDto loginDto)
        {
            var (userDto, tokenDto) = await _authService.LoginAdminAsync(loginDto);
            var token = new Token
            {
                AccessToken = tokenDto.AccessToken,
                RefreshToken = tokenDto.RefreshToken
            };
            return Ok(new ApiResponse<object>
            {
                StatusCode = 200,
                Success = true,
                Message = "Đăng nhập thành công.",
                Data = userDto,
                Token = token
            });
        }

    

        [HttpPost("google-login")]
        [ValidationFilter]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GoogleLogin([FromBody] LoginGoogleDto loginGoogleDto)
        {
            var (userDto, tokenDto) = await _authService.LoginWithGoogleAsync(loginGoogleDto.Credential);
            var token = new Token
            {
                AccessToken = tokenDto.AccessToken,
                RefreshToken = tokenDto.RefreshToken
            };
            return Ok(new ApiResponse<object>
            {
                StatusCode = 200,
                Success = true,
                Message = "Đăng nhập thành công.",
                Data = new { User = userDto },
                Token = token
            });
        }


        [HttpPut("change-password")]
        [ValidationFilter]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordDto changePasswordDto)
        {
            await _authService.ChangePasswordAsync(changePasswordDto);
            return Ok(new ApiResponse<object>
            {
                StatusCode = 200,
                Success = true,
                Message = "Đổi mật khẩu thành công."
            });
        }

        [HttpPost("refresh-token")]
        [ValidationFilter]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TokenDto>> RefreshToken([FromBody] TokenDto tokenDto)
        {
            var newToken = await _authService.RefreshTokenAsync(tokenDto);
            var token = new Token
            {
                AccessToken = newToken.AccessToken,
                RefreshToken = newToken.RefreshToken
            };
            return Ok(new ApiResponse<object>
            {
                StatusCode = 200,
                Success = true,
                Message = "Refresh token thành công.",
                Token = token
            });
        }
    }
}
