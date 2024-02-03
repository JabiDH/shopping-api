namespace ShoppingCart.Dtos.CartItems
{
    public class CartItemsRequestDto
    {
        public string Email { get; set; }
        public List<CartItemRequestDto> CartItems { get; set; }
    }
}
