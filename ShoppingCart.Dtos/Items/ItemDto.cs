using ShoppingCart.Dtos.Categories;
using ShoppingCart.Dtos.Common;
using ShoppingCart.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Dtos.Items
{
    public class ItemDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? ImagePath { get; set; }
        public decimal Price { get; set; }
        public CategoryDto Category { get; set; }
        public long CategoryId { get; set; }
        public List<ItemImageDto> Images { get; set; }
    }
}
