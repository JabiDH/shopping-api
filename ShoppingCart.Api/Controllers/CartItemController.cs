using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Dtos.CartItems;
using ShoppingCart.Services.CartItems;

namespace ShoppingCart.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize(Roles = "User")]
    public class CartItemController : ControllerBase
    {
        private readonly ICartItemsService cartItemsService;
        public CartItemController(ICartItemsService cartItemsService)
        {
            this.cartItemsService = cartItemsService;
        }

        [HttpGet]
        [Route("{email}")]
        public async Task<IActionResult> GetCartItems([FromRoute] string email)
        { 
            var response = await cartItemsService.GetCartItemsAsync(email);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> SaveCartItems([FromBody] CartItemsRequestDto request)
        { 
            var response = await cartItemsService.SaveCartItemsAsync(request);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> RemoveCartItems([FromBody] CartItemsRequestDto request)
        {
            var response = await cartItemsService.RemoveCartItemsAsync(request);
            return Ok(response);
        }
    }
}
