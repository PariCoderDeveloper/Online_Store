using Shop.Domain.Entities.Product;

namespace Shop.Application.Services.Product.Queries.GetDetailProductAdmin
{
    public class ProductDetailForAdminDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Brand { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int Inventory { get; set; }
        public int VisitedCount { get; set; }
        public bool Displayed { get; set; }
        public List<ProductDetailImageDto> productImages { get; set; }
        public List<ProductDetailFeatureDto> productFeatures { get; set; }
    }
}
