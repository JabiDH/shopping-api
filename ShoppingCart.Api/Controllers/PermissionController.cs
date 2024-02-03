using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Services.Permissions;

namespace ShoppingCart.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PermissionController : ControllerBase
    {
        private readonly IPermissionsService permissionsService;

        public PermissionController(IPermissionsService permissionService)
        {
            permissionsService = permissionService;
        }

        [HttpGet]
        public async Task<IActionResult> HasPermission([FromQuery] string email, [FromQuery] string role)
        {
            var hasPermission = await permissionsService.HasPermission(email, role);
            return Ok(hasPermission);
        }
    }
}
