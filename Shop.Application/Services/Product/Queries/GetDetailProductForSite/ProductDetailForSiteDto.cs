namespace Shop.Application.Services.Product.Queries.GetDetailProductForSite
{
    public class ProductDetailForSiteDto
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Brand { get; set; }
        public string Category { get; set; }
        public int Inventory { get; set; }
        public int Price { get; set; }
        public int VisitedCount { get; set; }
        public string Description { get; set; }
        public List<string> ImageSrc { get; set; }
        public List<ProductDetailForSite_FeatureDto> Features { get; set; } 
    }
}
