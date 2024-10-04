using Shop.Domain.Commen;
using Shop.Domain.Entities.Cart;
using Shop.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Entities.Cart
{
    public class Carts : BaseEntity
    {
        public virtual User Users { get; set; }
        public long? UserId { get; set; }
        public Guid BrowserId { get; set; }
        public bool Finished { get; set; }
        public ICollection<CartItem> Items { get; set; }
    }
}
