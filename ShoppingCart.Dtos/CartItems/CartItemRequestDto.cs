using System.ComponentModel.DataAnnotations;

namespace ShoppingCart.Dtos.CartItems
{
    public class CartItemRequestDto
    {
        [Required]
        public long ItemId { get; set; }
        
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }      
        
        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }
    }
}
