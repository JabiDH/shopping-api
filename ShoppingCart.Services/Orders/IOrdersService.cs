using ShoppingCart.Dtos.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Services.Orders
{
    public interface IOrdersService
    {
        Task<OrdersResponseDto> GetAllOrdersAsync(string? email = null);        
        Task<OrderResponseDto> GetOrderAsync(long id);
        Task<OrderResponseDto> UpsertOrderAsync(long id, UpsertOrderRequestDto requestDto);
        Task<OrderResponseDto> DeleteOrderAsync(long id);
    }
}
