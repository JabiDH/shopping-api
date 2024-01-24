using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Models.DataModels
{
    public class Category
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string? ImagePath { get; set; }
        public IEnumerable<Item> Items { get; set; }
    }
}
