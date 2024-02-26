using ShoppingCart.Dtos.Items;
using ShoppingCart.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Dtos.Orders
{
    public class OrderItemDto
    {
        public long Id { get; set; }
        public long ItemId { get; set; }
        public long OrderId { get; set; }
        public decimal Price { get; set; }
        public decimal SalesTax { get; set; }
        public decimal TaxRate { get; set; }
        public int Quantity { get; set; }
        public ItemDto? Item { get; set; }
    }
}
