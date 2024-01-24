using ShoppingCart.Dtos.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Services.Auth
{
    public interface IAuthService
    {
        Task<RegisterResponseDto> RegisterAsync(RegisterRequestDto request);
        Task<LoginResponseDto> LoginAsync(LoginRequestDto request);

    }
}
