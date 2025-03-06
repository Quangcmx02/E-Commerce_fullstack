using AsmC5.Common.Request;
using AsmC5.Common.Response;
using AsmC5.Contracts;
using AsmC5.DTOs.FoodItemDtos;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using AsmC5.DTOs.ComboDtos;
using AsmC5.Interfaces;
using AsmC5.Fillters;
using Microsoft.AspNetCore.Authorization;

namespace AsmC5.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    public class ComboController : Controller
    {
        private readonly IComboService _foodItemService;
        public ComboController(IComboService foodItemService)
        {
            _foodItemService = foodItemService;
        }
        [HttpGet]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<FoodItemDto>>> GetProducts([FromQuery] ComboRequestParameters foodItemRequestParameters)
        {
            var (products, metaData) = await _foodItemService.GetAllComboAsync(foodItemRequestParameters);
            return Ok(new ApiResponse<object>
            {
                StatusCode = 200,
                Success = true,
                Message = "Lấy dữ liệu danh sách sản phẩm thành công.",
                Data = products,
                Pagination = metaData
            });
        }
        [HttpGet("{id:int}", Name = nameof(GetCombo))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<FoodItemDto>> GetCombo(int id)
        {
            var product = await _foodItemService.GetComboByIdAsync(id);
            return Ok(new ApiResponse<object>
            {
                StatusCode = 200,
                Success = true,
                Message = $"Lấy dữ liệu sản phẩm với Id {id} thành công.",
                Data = product
            });
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidationFilter]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateCombo([FromForm] ComboForCreateDto productDto)
        {
            var createdProduct = await _foodItemService.CreateComboAsync(productDto);
            return StatusCode(201, new ApiResponse<object>
            {
                StatusCode = 201,
                Success = true,
                Message = "Tạo mới một sản phẩm thành công.",
                Data = createdProduct
            });
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _foodItemService.DeleteProductAsync(id);
            return Ok(new ApiResponse<object>
            {
                StatusCode = 200,
                Success = true,
                Message = $"Xóa sản phẩm với Id {id} thành công."
            });
        }
    }
}
