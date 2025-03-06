using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using AsmC5.Common.Request;
using AsmC5.Common.Response;
using AsmC5.Contracts;
using AsmC5.DTOs.FoodItemDtos;
using AsmC5.Interfaces;
using AsmC5.Fillters;
using Microsoft.AspNetCore.Authorization;

namespace AsmC5.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    public class FoodItemController : Controller
    {
        private readonly IFoodItemService _foodItemService;
        public FoodItemController(IFoodItemService foodItemService)
        {
           _foodItemService = foodItemService;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<FoodItemDto>>> GetProducts([FromQuery] FoodItemRequestParameters foodItemRequestParameters)
        {
            var (products, metaData) = await _foodItemService.GetAllFoodItemAsync(foodItemRequestParameters);
            return Ok(new ApiResponse<object>
            {
                StatusCode = 200,
                Success = true,
                Message = "Lấy dữ liệu danh sách sản phẩm thành công.",
                Data = products,
                Pagination = metaData
            });
        }
        [HttpGet("{id:int}", Name = nameof(GetFoodItem))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<FoodItemDto>>  GetFoodItem(int id)
        {
            var product = await _foodItemService.GetFoodItemByIdAsync(id);
            return Ok(new ApiResponse<object>
            {
                StatusCode = 200,
                Success = true,
                Message = $"Lấy dữ liệu sản phẩm với Id {id} thành công.",
                Data = product
            });
        }
        [HttpGet("category/{categoryId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<FoodItemDto>>> GetFoodItemsByCategoryId(int categoryId)
        {
            var foodItems = await _foodItemService.GetFoodItemByCategoryIdAsync(categoryId);

            if (!foodItems.Any())
            {
                return NotFound(new ApiResponse<object>
                {
                    StatusCode = 404,
                    Success = false,
                    Message = $"Không tìm thấy sản phẩm nào trong danh mục có Id {categoryId}.",
                    Data = null
                });
            }

            return Ok(new ApiResponse<object>
            {
                StatusCode = 200,
                Success = true,
                Message = $"Lấy danh sách sản phẩm theo danh mục Id {categoryId} thành công.",
                Data = foodItems
            });
        }
        [HttpPost]
        [ValidationFilter]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateProduct([FromForm] FoodItemForCreateDto productDto)
        {
            var createdProduct = await _foodItemService.CreateProductAsync(productDto);
            return StatusCode(201, new ApiResponse<object>
            {
                StatusCode = 201,
                Success = true,
                Message = "Tạo mới một sản phẩm thành công.",
                Data = createdProduct
            });
        }

        [HttpPut("{id:int}")]
        [ValidationFilter]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateProduct(
            int id,
            [FromForm] FoodItemForUpdateDto productDto)
        {
            var updatedProduct = await _foodItemService.UpdateProductAsync(id, productDto);
            return Ok(new ApiResponse<object>
            {
                StatusCode = 200,
                Success = true,
                Message = $"Cập nhật dữ liệu sản phẩm với Id {id} thành công.",
                Data = updatedProduct
            });
        }
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
