using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Services.Categories;

namespace ShoppingCart.Api.Controllers.Category
{
    [Route("api/[controller]/[action]")]
    [ApiController]
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
    }
}
