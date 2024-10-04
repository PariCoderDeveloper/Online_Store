using Microsoft.EntityFrameworkCore;
using Shop.Application.Interfaces.Context;
using Shop.Ccommon.Dto;

namespace Shop.Application.Services.Commen.Query.GetMenuService
{
    public class GetMenuService : IGetMenuService
    {
        private readonly IDataBaseContext _context;
        public GetMenuService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto<List<MenuServiceDto>> Execute()
        {
            var categories = _context.Category
                .Include(x => x.SubCategory)
                .Where(x => x.ParentCategoryId == null)
                .Select(x => new MenuServiceDto
                {
                    CatId = x.Id,
                    Name = x.Name,
                    Child = x.SubCategory.ToList().Select(child => new MenuServiceDto
                    {
                        CatId = child.Id,
                        Name = child.Name
                    }).ToList()
                }).ToList();

            return new ResultDto<List<MenuServiceDto>>
            {
                Data = categories,
                IsSuccess = true,
                Message = ""
            };
        }
    }
}
