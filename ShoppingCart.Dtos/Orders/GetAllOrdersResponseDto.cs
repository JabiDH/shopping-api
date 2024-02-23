using ShoppingCart.Dtos.Common.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Dtos.Orders
{
    public class GetAllOrdersResponseDto : BaseResponseDto
    {
        public List<OrderDto> Orders { get; set; }
    }
}
