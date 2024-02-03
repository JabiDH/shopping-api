using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Dtos.Auth;
using ShoppingCart.Services.Auth;

namespace ShoppingCart.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService authService;
        public AuthController(IAuthService authService)
        {
            this.authService = authService;
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto request)
        {
            var response = await authService.RegisterAsync(request);
            if (response != null)
            {
                return response.Succeeded ? Ok(response) : BadRequest(response);
            }
            return BadRequest("Unhandle error occured on user register.");
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto request)
        {
            var response = await authService.LoginAsync(request);
            if (response != null)
            {
                return response.Succeeded ? Ok(response) : BadRequest(response);
            }
            return BadRequest("Unhandle error occured on user login.");
        }
    }
}
