using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Dtos.Orders;
using ShoppingCart.Services.Orders;

namespace ShoppingCart.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class OrderController : ControllerBase
    {
        private readonly IOrdersService ordersService;
        private readonly ILogger<OrderController> logger;
        private readonly IConfiguration configuration;
        public OrderController(IOrdersService ordersService, ILogger<OrderController> logger, IConfiguration configuration)
        {
            this.ordersService = ordersService;
            this.logger = logger;
            this.configuration = configuration;            
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllOrders()
        {
            var response = await ordersService.GetAllOrdersAsync();
            if (response != null)
            {
                return response.Succeeded ? Ok(response) : BadRequest(response);
            }
            return BadRequest("Unhandle error occured on " + nameof(GetAllOrders));
        }

        [HttpGet]
        [Route("{id:long}")]
        public async Task<IActionResult> GetOrder([FromRoute] long id)
        {
            var response = await ordersService.GetOrderAsync(id);
            return response.Succeeded ? Ok(response) : NotFound(response);
        }

        [HttpGet]
        [Route("{email}")]
        public async Task<IActionResult> GetUserOrders([FromRoute] string email)
        {
            var response = await ordersService.GetAllOrdersAsync(email);
            return response.Succeeded ? Ok(response) : NotFound(response);
        }

        [HttpPost]        
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderRequestDto request)
        {
            var response = await ordersService.CreateOrderAsync(request);
            return response.Succeeded ? Ok(response) : BadRequest(response);
        }

        //[HttpPut]
        //[Route("{id:long}")]
        //[Authorize(Roles = "Admin")]
        //public async Task<IActionResult> UpdateOrder([FromRoute] long id, UpsertItemRequestDto request)
        //{            
        //    var response = await ordersService.UpsertItemAsync(id, request);
        //    return response.Succeeded ? Ok(response) : BadRequest(response);
        //}

        [HttpDelete]
        [Route("{id:long}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteOrder([FromRoute] long id)
        {
            var response = await ordersService.DeleteOrderAsync(id);
            return response.Succeeded ? Ok(response) : BadRequest(response);
        }
    }
}
