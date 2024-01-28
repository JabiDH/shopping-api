using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Dtos.Items;
using ShoppingCart.Services.Items;

namespace ShoppingCart.Api.Controllers.Item
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class ItemController : ControllerBase
    {
        private readonly IItemsService itemsService;
        public ItemController(IItemsService itemsService)
        {
            this.itemsService = itemsService;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAllItems()
        {
            var response = await itemsService.GetAllItemsAsync();
            if (response != null)
            {
                return response.Succeeded ? Ok(response) : BadRequest(response);
            }
            return BadRequest("Unhandle error occured on " + nameof(GetAllItems));
        }
        
        [HttpGet]
        public async Task<IActionResult> SearchItems([FromQuery] SearchItemsRequestDto requestDto)
        {
            var response = await itemsService.SearchItemsAsync(requestDto);
            if (response != null)
            {
                return response.Succeeded ? Ok(response) : BadRequest(response);
            }
            return BadRequest("Unhandle error occured on " + nameof(SearchItems));
        }

        [HttpGet]
        [Route("{id:long}")]
        public async Task<IActionResult> GetItem([FromRoute] long id)
        { 
            var response = await itemsService.GetItemAsync(id);
            return response.Succeeded? Ok(response) : NotFound(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateItem([FromBody] UpsertItemRequestDto item)
        {
            var response = await itemsService.UpsertItemAsync(0, item);
            return response.Succeeded ? Ok(response) : BadRequest(response);
        }

        [HttpPut]
        [Route("{id:long}")]
        public async Task<IActionResult> UpdateItem([FromRoute] long id, UpsertItemRequestDto item)
        {
            var response = await itemsService.UpsertItemAsync(id, item);
            return response.Succeeded ? Ok(response) : BadRequest(response);
        }

        [HttpDelete]
        [Route("{id:long}")]
        public async Task<IActionResult> DeleteItem([FromRoute] long id)
        {
            var response = await itemsService.DeleteItemAsync(id);
            return response.Succeeded ? Ok(response) : BadRequest(response);
        }
    }
}
