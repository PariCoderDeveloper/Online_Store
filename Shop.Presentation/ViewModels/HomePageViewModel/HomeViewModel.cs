using Shop.Application.Services.Commen.Query.GetMenuService;
using Shop.Application.Services.HomePage.Query.GetSliders;
using Shop.Application.Services.Product.Queries.GetProductForSite;
using Shop.Domain.Entities.HomePage;

namespace Shop.Presentation.ViewModels.HomePageViewModel
{
    public class HomeViewModel
    {
        public List<GetSliderDto> Slider { get; set; }
        public ResultGetProductForSiteDto PapularProducts { get; set; }
        public ResultGetProductForSiteDto NewestProducts { get; set; }
        public ResultGetProductForSiteDto CheapestProducts { get; set; }
        public ResultGetProductForSiteDto PowderProducts { get; set; }
        public ResultGetProductForSiteDto MokhamerProducts { get; set; }
    }
}
