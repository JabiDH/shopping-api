using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Dtos.Items;
using ShoppingCart.Services.Items;

namespace ShoppingCart.Api.Controllers.Item
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IItemService itemService;
        public ItemController(IItemService itemService)
        {
            this.itemService = itemService;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAllItems()
        {
            var response = await itemService.GetAllItemsAsync();
            if (response != null)
            {
                return response.Succeeded ? Ok(response) : BadRequest(response);
            }
            return BadRequest("Unhandle error occured on " + nameof(GetAllItems));
        }
        
        [HttpGet]
        public async Task<IActionResult> SearchItems([FromQuery] SearchItemsRequestDto requestDto)
        {
            var items = await itemService.SearchItemsAsync(requestDto);
            return Ok(items);
        }

    }
}
