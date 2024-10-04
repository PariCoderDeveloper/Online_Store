using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Interfaces.FacadPattern;
using Shop.Application.Services.Product.Queries.GetProductForAdmin;
using Shop.Presentation.Models;
using System.Diagnostics;
using Shop.Presentation.ViewModels.HomePageViewModel;
using Shop.Application.Services.Product.Queries.GetProductForSite;

namespace Shop.Presentation.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductFacad _facad;
        private readonly IHomePageFacad _homePagefacad;
        public HomeController(ILogger<HomeController> logger, IProductFacad facad,
            IHomePageFacad homePagefacad)
        {
            _logger = logger;
            _facad = facad;
            _homePagefacad = homePagefacad;
        }

        public async Task<IActionResult> Index(int Page = 1)
        {
            try
            {
                var HomePage = new HomeViewModel
                {
                    Slider = _homePagefacad.getSliders.ExecuteAsync().Result.Data,
                    PapularProducts = _facad.getProductForSiteService.ExecuteAsync(8, Page, null, null, Order.popularity).Result.Data,
                    NewestProducts = _facad.getProductForSiteService.ExecuteAsync(3, Page, null, null, Order.date).Result.Data,
                    CheapestProducts = _facad.getProductForSiteService.ExecuteAsync(8, Page, null, null, Order.price).Result.Data,
                    PowderProducts = _facad.getProductForSiteService.ExecuteAsync(4, Page, 1, null, Order.popularity).Result.Data,
                    MokhamerProducts = _facad.getProductForSiteService.ExecuteAsync(4, Page, 5, null, Order.popularity).Result.Data
                };
                return View("~/Views/Home/Index.cshtml", HomePage);
            }
            catch (Exception ex)
            {
                return View("~/Views/Home/Index.cshtml", ex);
            }
        }


        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> Buy(long Id)
        {
            try
            {
                var result = await _facad.getDetailProductAdmin.ExecuteAsync(Id);
                return View("~/Views/Home/Buy.cshtml", result.Data);
            }
            catch (Exception ex)
            {
                return View("~/Views/Home/Buy.cshtml", ex);
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult SignOut()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Index", "Home");
        }

    }
}
