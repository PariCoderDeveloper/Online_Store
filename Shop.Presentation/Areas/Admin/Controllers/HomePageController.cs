using Microsoft.AspNetCore.Mvc;
using Shop.Application.Interfaces.FacadPattern;
using Shop.Application.Services.HomePage.Cammand.AddNewSliderService;
using Shop.Application.Services.HomePage.HomePageFacad;
using Shop.Domain.Entities.HomePage;

namespace Shop.Presentation.Areas.Admin.Controllers
{
    public class HomePageController : Controller
    {
        private readonly IHomePageFacad _homePageFacad;
        public HomePageController(IHomePageFacad homePageFacad)
        {
            _homePageFacad = homePageFacad;
        }
        public async Task<IActionResult> Index(int page = 1, int pagesize = 10)
        {
            var result = await _homePageFacad.getSliderForAdmin.ExecuteAsync(page, pagesize);
            return View("~/Areas/Admin/Views/HomePage/Index.cshtml", result.Data);
        }

        [HttpGet]
        public async Task<IActionResult> AddSlider(long? Id)
        {
            if (Id != null & Id.HasValue == true)
            {
              var slider = await _homePageFacad.getSliderWithId.ExecuteAsync(Id);
                if (slider.IsSuccess)
                {
                    return View("~/Areas/Admin/Views/HomePage/AddSlider.cshtml", slider.Data);
                }
            }
            return View("~/Areas/Admin/Views/HomePage/AddSlider.cshtml");

        }

        [HttpPost]
        public async Task<IActionResult> AddSlider(AddNewSliderDto request)
        {
            try
            {
                var result = await _homePageFacad.addNewSliderService.ExecuteAsync(request);
                return View("~/Areas/Admin/Views/HomePage/AddSlider.cshtml", result);
            }
            catch (Exception e)
            {
                return View("~/Areas/Admin/Views/HomePage/AddSlider.cshtml", e.Message);
            }

        }
    }
}
