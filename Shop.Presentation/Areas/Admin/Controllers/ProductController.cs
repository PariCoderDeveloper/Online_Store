using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Shop.Application.Interfaces.FacadPattern;
using Shop.Application.Services.Product.Command.AddNewProduct;
using Shop.Application.Services.Product.Queries.GetCategory;
using Shop.Ccommon.Dto;
using Shop.Presentation.ViewModels.ProductViewModel;

namespace Shop.Presentation.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductFacad _facad;
        private readonly IValidator<AddProductDto> _validator;
        public ProductController(IProductFacad facad, IValidator<AddProductDto> validator)
        {
            _facad = facad;
            _validator = validator;
        }

        public async Task<IActionResult> Index(int Page = 1, int PageSize = 20)
        {
            try
            {
                var result = await _facad.getProductForAdmin.ExecuteAsync(Page, PageSize);
                return View("~/Areas/Admin/Views/Product/Index.cshtml", result.Data);
            }
            catch (Exception ex)
            {
                return View("~/Areas/Admin/Views/Product/Index.cshtml", ex);
            }
        }

        public async Task<IActionResult> Details(long Id)
        {
            try
            {
                var result = await _facad.getDetailProductAdmin.ExecuteAsync(Id);
                return View("~/Areas/Admin/Views/Product/Details.cshtml", result.Data);
            }
            catch (Exception ex)
            {
                return View("~/Areas/Admin/Views/Product/Details.cshtml", ex);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var categoriesResult = await _facad.getAllCategories.ExecuteAsync();
            var result = categoriesResult.Data.Select(x => new ProductViewModel
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
            var categories = new SelectList(result, "Id", "Name");
            ViewBag.CategoryList = categories;

            return View("~/Areas/Admin/Views/Product/Create.cshtml");
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddProductDto request, IFormFileCollection Image)
        {
            ValidationResult validationResult = _validator.Validate(new AddProductDto
            {
                Brand = request.Brand,
                CategoryId = request.CategoryId,
                Description = request.Description,
                Inventory = request.Inventory,
                Name = request.Name,
                Price = request.Price
            });
            if (!validationResult.IsValid)
            {
                return Json(new ResultDto
                {
                    IsSuccess = false,
                    Message = string.Join(" * ", validationResult.Errors.Select(e => e.ErrorMessage))
                });
            }
            //IFormFileCollection image = new IFormFileCollection();
            //for (int i = 0; i < Request.Form.Files.Count; i++)
            //{
            //    var file = Request.Form.Files[i];
            //    image.Add(file);
            //}
            request.Image = Image;
            var result = await _facad.addNewProductService.ExecuteAsync(request);
            return Json(result);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(long ProductId)
        {
            var result = await _facad.RemoveProduct.ExecuteAsync(ProductId);
            return Json(result);
        }
    }
}
