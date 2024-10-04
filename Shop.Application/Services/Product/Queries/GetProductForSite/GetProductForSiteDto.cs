namespace Shop.Application.Services.Product.Queries.GetProductForSite
{
    public class GetProductForSiteDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public int Price { get; set; }
        public string Category { get; set; }
        public string ImageSrc { get; set; }
        public int Star { get; set; }

    }
}
