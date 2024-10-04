using Microsoft.AspNetCore.Mvc;
using Shop.Application.Interfaces.FacadPattern;
using Shop.Application.Services.Product.Queries.GetProductForSite;

namespace Shop.Presentation.Controllers
{
    public class ListProductsController : Controller
    {
        private readonly IProductFacad _facad;
        public ListProductsController(IProductFacad facad)
        {
            _facad = facad;
        }

        public async Task<IActionResult> Index(int PageSize = 8,int Page = 1, long? CatId = null 
            , string? SearchKey = null, Order orderby = 0)
        {
            try
            {
                var result = await _facad.getProductForSiteService.ExecuteAsync(PageSize, Page, CatId, SearchKey , orderby);
                return View("~/Views/ListProducts/Index.cshtml", result.Data);
            }
            catch (Exception ex)
            {
                return View("~/Views/Error/Error.cshtml");
            }       
        }

        public async Task<IActionResult> ProductDetail(long Id)
        {
            try
            {
                var result = await _facad.getDetailProductForSite.ExecuteAsync(Id);
                return View("~/Views/ListProducts/ProductDetail.cshtml", result.Data);
            }
            catch (Exception)
            {
                return View("~/Views/Error/Error.cshtml");
            }
        }
    }
}
