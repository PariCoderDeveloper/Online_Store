using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Shop.Application.Services.Commen.Query.GetMenuService;

namespace Shop.Presentation.ViewComponents
{
    public class GetMenu : ViewComponent
    {
        private readonly IGetMenuService   _service;
        public GetMenu(IGetMenuService service)
        {
            _service = service;
        }

        public IViewComponentResult Invoke()
        {
            var menuItem = _service.Execute();
            return View(viewName: "GetMenu",menuItem.Data);
        }
    }
}
