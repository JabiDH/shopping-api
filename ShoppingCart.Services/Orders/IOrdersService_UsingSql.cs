using ShoppingCart.Dtos.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Services.Orders
{
    public interface IOrdersService_UsingSql
    {
        Task<OrdersResponseDto> GetOrdersAsync(long? id);
        Task<OrderResponseDto> CreateOrderAsync(UpsertOrderRequestDto requestDto);
    }
}
