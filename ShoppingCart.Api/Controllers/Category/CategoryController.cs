using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Dtos.Categories;
using ShoppingCart.Services.Categories;

namespace ShoppingCart.Api.Controllers.Category
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoriesService categoriesService;

        public CategoryController(ICategoriesService categoriesService)
        {
            this.categoriesService = categoriesService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var response = await categoriesService.GetAllCategoriesAsync();
            if (response != null)
            {
                return Ok(response);
            }
            return BadRequest("Unhandle error occured on " + nameof(GetAllCategories));
        }

        [HttpGet]
        [Route("{id:long}")]
        public async Task<IActionResult> GetCategory([FromRoute]long id)
        {
            var response = await categoriesService.GetCategoryAsync(id);
            return response.Succeeded ? Ok(response) : BadRequest(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] UpsertCategoryRequestDto request)
        {
            var response = await categoriesService.UpsertCategoryAsync(0, request);
            return response.Succeeded ? Ok(response) : BadRequest(response);
        }

        [HttpPut]
        [Route("{id:long}")]
        public async Task<IActionResult> UpdateCategory([FromRoute] long id, UpsertCategoryRequestDto request)
        {
            var response = await categoriesService.UpsertCategoryAsync(id, request);
            return response.Succeeded ? Ok(response) : BadRequest(response);
        }

        [HttpDelete]
        [Route("{id:long}")]
        public async Task<IActionResult> DeleteCategory([FromRoute] long id)
        {
            var response = await categoriesService.DeleteCategoryAsync(id);
            return response.Succeeded ? Ok(response) : BadRequest(response);
        }
    }
}
