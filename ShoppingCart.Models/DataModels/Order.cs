using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Models.DataModels
{
    public class Order
    {
        public long Id { get; set; }
        public string Email { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ClosedOn { get; set; }
        public string Status { get; set; }
        public decimal SubTotal { get; set; }
        public decimal SalesTax { get; set; }
        public decimal TaxRate { get; set; }
        public decimal Total { get; set; }
        public List<OrderItem> OrderItems { get; set; }
    }
}
