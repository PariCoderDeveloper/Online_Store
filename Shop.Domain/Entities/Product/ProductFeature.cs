using Shop.Domain.Commen;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.Domain.Entities.Product
{
    public class ProductFeature : BaseEntity
    {
        [ForeignKey("Id")]
        public Products Products { get; set; }
        public long ProductId { get; set; }
        public string DisplayName { get; set; }
        public string Value { get; set; }
    }
}
