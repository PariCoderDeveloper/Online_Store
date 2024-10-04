using Microsoft.AspNetCore.Mvc;
using Shop.Application.Services.Cart;
using Shop.Presentation.Utilities;

namespace Shop.Presentation.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService _cartService;
        private readonly CookiesManager _cookiesManager;
        public CartController(ICartService cartService, CookiesManager cookiesManager)
        {
            _cartService = cartService;
            _cookiesManager = cookiesManager;
        }
        public async Task<IActionResult> Index()
        {
            Guid browserId = _cookiesManager.GetBrowserId(HttpContext);
            var cartItems = await _cartService.GetItemsCart(browserId,null);
            return View("~/Views/Cart/Index.cshtml", cartItems.Data);
        }

        public async Task<IActionResult> AddToCart(long ProductId) 
        {
            var browserId = _cookiesManager.GetBrowserId(HttpContext);
            var resultAdd = await _cartService.AddCart(ProductId, browserId);
            return RedirectToAction("Index",resultAdd);
        }

        public async Task<IActionResult> DeleteFromCart(long ProductId)
        {
            Guid browserId =  _cookiesManager.GetBrowserId(HttpContext);
            var resultdto = await _cartService.DeleteFromCart(ProductId, browserId);
            return RedirectToAction("Index",resultdto);
        }
    }
}
