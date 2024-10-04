using Shop.Domain.Commen;
using Shop.Domain.Entities.Product;

namespace Shop.Domain.Entities.Cart
{
    public class CartItem : BaseEntity
    {
        public virtual Products Product { get; set; }
        public long ProductId { get; set; }
        public int Count { get; set; }
        public int Price { get; set; }
        public virtual Carts Cart { get; set; }
        public long CartId { get; set; }
    }
}
