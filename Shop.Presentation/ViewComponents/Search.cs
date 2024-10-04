using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Shop.Application.Services.Product.Queries.GetParentCategory;

namespace Shop.Presentation.ViewComponents
{
    public class Search : ViewComponent
    {
        private readonly IGetParentCategoryService _getParentCategoryService;
        public Search(IGetParentCategoryService getParentCategoryService)
        {
            _getParentCategoryService = getParentCategoryService;
        }

        public IViewComponentResult Invoke()
        {
            var result = _getParentCategoryService.ExecuteAsync().Result.Data;
            ViewBag.Categoriess = new SelectList(result.Categories,  "CatId", "ParentName");
            return View(viewName : "Search" );
        }
    }
}
