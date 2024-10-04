using Shop.Domain.Commen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Entities.Product
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public virtual Category ParentCategory { get; set; }
        public long?  ParentCategoryId { get; set; }
        public virtual ICollection<Category> SubCategory { get; set; }
      
    }
}
