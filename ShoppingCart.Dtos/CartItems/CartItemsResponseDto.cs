using ShoppingCart.Dtos.Common.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Dtos.CartItems
{
    public class CartItemsResponseDto : BaseResponseDto
    {
        public List<CartItemResponseDto> CartItems { get; set; }
        public decimal Subtotal { get; set; }
        public decimal SalesTax { get; set; }
        public decimal Total { get; set; }
    }
}
