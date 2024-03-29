﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Dtos.Items;
using ShoppingCart.Services.Items;

namespace ShoppingCart.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class ItemController : ControllerBase
    {
        private readonly IItemsService itemsService;
        private readonly ILogger<ItemController> logger;
        private readonly IConfiguration configuration;
        public ItemController(IItemsService itemsService, ILogger<ItemController> logger, IConfiguration configuration)
        {
            this.itemsService = itemsService;
            this.logger = logger;
            this.configuration = configuration;            
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
            return response.Succeeded ? Ok(response) : NotFound(response);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateItem([FromBody] UpsertItemRequestDto request)
        {
            var response = await itemsService.UpsertItemAsync(0, request);
            return response.Succeeded ? Ok(response) : BadRequest(response);
        }

        [HttpPut]
        [Route("{id:long}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateItem([FromRoute] long id, UpsertItemRequestDto request)
        {
            var response = await itemsService.UpsertItemAsync(id, request);
            return response.Succeeded ? Ok(response) : BadRequest(response);
        }

        [HttpDelete]
        [Route("{id:long}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteItem([FromRoute] long id)
        {
            var response = await itemsService.DeleteItemAsync(id);
            return response.Succeeded ? Ok(response) : BadRequest(response);
        }
    }
}
