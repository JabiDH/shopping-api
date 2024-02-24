using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Models.DataModels
{
    public class OrderItem
    {
        public long Id { get; set; }
        public long ItemId { get; set; }
        public long OrderId { get; set; }
        public decimal Price { get; set; }
        public decimal SaleTax { get; set; }
        public int Quantity { get; set; }
        public Item Item { get; set; }
        public Order Order { get; set; }
    }
}
