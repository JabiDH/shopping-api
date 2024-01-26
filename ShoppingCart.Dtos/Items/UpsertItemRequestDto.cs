using ShoppingCart.Dtos.Categories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Dtos.Items
{
    public class UpsertItemRequestDto
    {
        public long? Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? ImagePath { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public long CategoryId { get; set; }
    }
}
