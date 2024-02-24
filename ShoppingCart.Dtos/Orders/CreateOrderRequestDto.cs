using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Dtos.Orders
{
    public class CreateOrderRequestDto
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]
        public decimal SaleTax { get; set; }
        public List<OrderItemDto> OrderItems { get; set; }
    }
}
