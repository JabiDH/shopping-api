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
        Task<GetAllOrdersResponseDto> GetAllOrdersAsync(string? email = null);        
        Task<GetOrderResponseDto> GetOrderAsync(long id);
        Task<CreateOrderResponseDto> CreateOrderAsync(CreateOrderRequestDto requestDto);
        Task<DeleteOrderResponseDto> DeleteOrderAsync(long id);
    }
}
