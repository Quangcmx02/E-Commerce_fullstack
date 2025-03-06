using AsmC5.Common.Request;
using AsmC5.Common.Response;
using AsmC5.Contracts;
using AsmC5.DTOs.UserDtos;
using AsmC5.Fillters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using AsmC5.DTOs.AuthDtos;

namespace AsmC5.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    public class UsersController : Controller
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetUsers([FromQuery] UserRequestParameters userRequestParameters)
        {
            var (users, metaData) = await _userService.GetUsersAsync(userRequestParameters);
            return Ok(new ApiResponse<object>
            {
                StatusCode = 200,
                Success = true,
                Message = "Lấy danh sách người dùng thành công.",
                Data = users,
                Pagination = metaData
            });
        }
        [Authorize]
        [HttpPut("current")]
        [ValidationFilter]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UserDto>> UpdateCurrentUser([FromBody] UpdateProfileDto userForUpdateDto)
        {
            var user = await _userService.UpdateCurrentUserAsync(User, userForUpdateDto);
            return Ok(new ApiResponse<object>
            {
                StatusCode = 200,
                Success = true,
                Message = "Cập nhật thông tin người dùng hiện tại thành công.",
                Data = user
            });
        }

        [Authorize]
        [HttpGet("current")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UserDto>> GetCurrentUser()
        {
            var user = await _userService.GetCurrentUserAsync(User);
            return Ok(new ApiResponse<UserDto>
            {
                StatusCode = 200,
                Success = true,
                Message = "Lấy dữ liệu người dùng hiện tại thành công.",
                Data = user
            });
        }
        [Authorize(Roles = "Admin")]
        [HttpPut("{userId}")]
        [ValidationFilter]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UserDto>> UpdateUserForAdmin(string userId, [FromBody] UserUpdateForAdmin userForUpdateDto)
        {
         
                await _userService.UpdateUserForAdminAsync(userId, userForUpdateDto);
                return Ok(new ApiResponse<object>
                {
                    StatusCode = 200,
                    Success = true,
                    Message = "Cập nhật người dùng thành công.",
                    Data = userId
                });
        }
        [HttpGet("{id}", Name = nameof(GetUser))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UserDto>> GetUser(string id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            return Ok(new ApiResponse<object>
            {
                StatusCode = 200,
                Success = true,
                Message = $"Lấy dữ liệu người dùng với Id {id} thành công.",
                Data = user
            });
        }
        [HttpGet("email/{email}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UserDto>> GetUserByEmail(string email)
        {
            var user = await _userService.GetUserByEmailAsync(email);
            return Ok(new ApiResponse<object>
            {
                StatusCode = 200,
                Success = true,
                Message = $"Lấy dữ liệu người dùng với email {email} thành công.",
                Data = user
            });
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidationFilter]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateUser([FromBody] SignUpDto userForCreateDto)
        {
            var user = await _userService.CreateUserAsync(userForCreateDto);
            return StatusCode(201, new ApiResponse<object>
            {
                StatusCode = 201,
                Success = true,
                Message = "Tạo mới người dùng thành công.",
                Data = user
            });
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteUser(string id)
        {
            await _userService.DeleteUserAsync(id);
            return Ok(new ApiResponse<object>
            {
                StatusCode = 200,
                Success = true,
                Message = $"Xóa người dùng với Id {id} thành công."
            });
        }
        [HttpPost("{id}/changepassword")]
        [ValidationFilter]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ChangePassword(string id, [FromBody] ChangePasswordDto changePasswordDto)
        {
            await _userService.ChangePasswordAsync(id, changePasswordDto);
            return Ok(new ApiResponse<object>
            {
                StatusCode = 200,
                Success = true,
                Message = $"Thay đổi mật khẩu thành công cho người dùng với Id {id}."
            });
        }
    }
}
