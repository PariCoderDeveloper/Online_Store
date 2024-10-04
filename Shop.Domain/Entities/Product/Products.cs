using Shop.Domain.Commen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Entities.Product
{
    public class Products : BaseEntity
    {
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int Inventory { get; set; }
        public bool Displayed { get; set; }
        public int VisitCount { get; set; } = 0;
        public virtual Category Category { get; set; }
        public long CategoryId { get; set; }
        public ICollection<ProductImage> ProductImages { get; set; }
        public ICollection<ProductFeature> ProductFeatures { get; set; }

    }
}
