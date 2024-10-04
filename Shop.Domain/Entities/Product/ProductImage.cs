using Shop.Domain.Commen;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.Domain.Entities.Product
{
    public class ProductImage : BaseEntity
    {
        [ForeignKey("Id")]
        public Products Products { get; set; }
        public long ProductId { get; set; }
        public string Src { get; set; }
    }
}
