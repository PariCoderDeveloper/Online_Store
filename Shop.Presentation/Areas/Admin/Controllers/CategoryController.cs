using Microsoft.AspNetCore.Mvc;
using Shop.Application.Interfaces.FacadPattern;
using Shop.Application.Services.Product.FacadPattern;

namespace Shop.Presentation.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IProductFacad _facad;
        public CategoryController(IProductFacad Facad)
        {
            _facad = Facad;
        }
        public async Task<IActionResult> Index(long? parentId,int page = 1,int pageSize = 20)
        {
            try
            {
                var result = await _facad.getCtegory.ExecuteAsync(parentId,page,pageSize);
                return View("~/Areas/Admin/Views/Category/Index.cshtml", result.Data);
            }catch(Exception ex)
            {
                return View("~/Areas/Admin/Views/Category/Index.cshtml", ex);
            }
        }

        [HttpGet]
        public IActionResult AddNewCategory(long? ParentId)
        {
            ViewBag.parentId = ParentId;
            return View("~/Areas/Admin/Views/Category/AddNewCategory.cshtml");
        }

        [HttpPost]
        public IActionResult AddNewCategory(long? ParentId, string Name)
        {
            var result = _facad.NewCategoryService.Execute(ParentId, Name);
            return Json(result);
        }

        [HttpPost]
        public IActionResult RemoveCategory(long Id)
        {
            var result = _facad.RemoveCategory.Execute(Id);
            return Json(result);
        }
    }
}
