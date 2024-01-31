using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Services.Permissions;

namespace ShoppingCart.Api.Controllers.Permission
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PermissionController : ControllerBase
    {
        private readonly IPermissionsService permissionsService;

        public PermissionController(IPermissionsService permissionService)
        {
            this.permissionsService = permissionService;
        }

        [HttpGet]
        public async Task<IActionResult> HasPermission([FromQuery] string email, [FromQuery] string role)
        {
            var hasPermission = await this.permissionsService.HasPermission(email, role);
            return Ok(hasPermission);
        }
    }
}
