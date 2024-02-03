using ShoppingCart.Dtos.CartItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Services.CartItems
{
    public interface ICartItemsService
    {
        Task<CartItemsResponseDto> GetCartItemsAsync(string email);
        Task<CartItemsResponseDto> SaveCartItemsAsync(CartItemsRequestDto request);
        Task<CartItemsResponseDto> RemoveCartItemsAsync(CartItemsRequestDto request);
    }
}
