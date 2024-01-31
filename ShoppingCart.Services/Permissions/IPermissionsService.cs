using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Services.Permissions
{
    public interface IPermissionsService
    {
        Task<bool> HasPermission(string email, string role);
    }
}
