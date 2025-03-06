using AsmC5.Common.Request;
using AsmC5.Common.Response;
using AsmC5.Contracts;
using AsmC5.DTOs.CategoryDtos;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using AsmC5.Fillters;
using Microsoft.AspNetCore.Authorization;

namespace AsmC5.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> GetCategories([FromQuery] CategoryRequestParameters categoryRequestParameters)
        {
            var (categories, metaData) = await _categoryService.GetAllCategoriesAsync(categoryRequestParameters);
            return Ok(new ApiResponse<object>
            {
                StatusCode = 200,
                Success = true,
                Message = "Lấy dữ liệu danh sách các danh mục thành công.",
                Data = categories,
                Pagination = metaData
            });
        }

        [HttpGet("{id:int}", Name = nameof(GetCategory))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CategoryDto>> GetCategory(int id)
        {
            var category = await _categoryService.GetCategoryByIdAsync(id);
            return Ok(new ApiResponse<object>
            {
                StatusCode = 200,
                Success = true,
                Message = $"Lấy dữ liệu danh mục với Id {id} thành công.",
                Data = category
            });
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidationFilter]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateCategory(
            [FromBody] CategoryForCreateDto categoryDto)
        {
            await _categoryService.CreateCategoryAsync(categoryDto);

            return StatusCode(201, new ApiResponse<object>
            {
                StatusCode = 201,
                Success = true,
                Message = $"Tạo mới một danh mục thành công.",
            });
        }
        [HttpPut("{id:int}")]
        [ValidationFilter]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateCategory(
            int id,
            [FromBody] CategoryForUpdateDto categoryDto)
        {
            await _categoryService.UpdateCategoryAsync(id, categoryDto);
            return Ok(new ApiResponse<object>
            {
                StatusCode = 200,
                Success = true,
                Message = $"Cập nhật dữ liệu danh mục với Id {id} thành công.",
            });
        }
        [HttpDelete("{id:int}")]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            await _categoryService.DeleteCategoryAsync(id);
            return Ok(new ApiResponse<object>
            {
                StatusCode = 200,
                Success = true,
                Message = $"Xóa danh mục với Id {id} thành công.",
            }); ;
        }


        [HttpGet("name/{name}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CategoryDto>> GetCategoryByName(string name)
        {
            var category = await _categoryService.GetCategoryByNameAsync(name);
            return Ok(new ApiResponse<object>
            {
                StatusCode = 200,
                Success = true,
                Message = $"Lấy dữ liệu danh mục với tên {name} thành công.",
                Data = category
            });
        }

    }
}
