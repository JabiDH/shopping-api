using ShoppingCart.Dtos.Common.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Dtos.Orders
{
    public class OrderResponseDto : BaseResponseDto
    {
        public OrderDto Order { get; set; }
    }
}
