using ShoppingCart.Models.DataModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Dtos.CartItems
{
    public class CartItemResponseDto
    {
        public long ItemId { get; set; }
        public string Email { get; set; }
        public Item Item { get; set; }
        public int Quantity { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
