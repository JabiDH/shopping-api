using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Services.Token
{
    public interface ITokenService
    {
        string CreateJwtToken(IdentityUser user, List<string> roles, long expireOnInSec);
    }
}
