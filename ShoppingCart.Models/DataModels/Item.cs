using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Models.DataModels
{
    public class Item
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? ImagePath { get; set; }
        public decimal Price { get; set; }
        public Category Category { get; set; }
        public long CategoryId { get; set; }
        public List<ItemImage> Images { get; set; }
    }
}
