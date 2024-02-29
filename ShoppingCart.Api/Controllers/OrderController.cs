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
            return Ok(await ordersService.GetAllOrdersAsync());
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
            return Ok(await ordersService.GetAllOrdersAsync(email));
        }

        [HttpPost]        
        public async Task<IActionResult> CreateOrder([FromBody] UpsertOrderRequestDto request)
        {
            var response = await ordersService.UpsertOrderAsync(0, request);
            return response.Succeeded ? Ok(response) : BadRequest(response);
        }

        [HttpPut]
        [Route("{id:long}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateOrder([FromRoute] long id, UpsertOrderRequestDto request)
        {
            var response = await ordersService.UpsertOrderAsync(id, request);
            return response.Succeeded ? Ok(response) : BadRequest(response);
        }

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
