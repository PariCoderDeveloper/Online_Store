namespace Shop.Application.Services.Cart
{
    public class CartDto{
        public int ProductCount { get; set; }
        public int SumAmount { get; set; }
        public List<CartItemDto> Items { get; set; }
    }
}
