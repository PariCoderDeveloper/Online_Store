using Microsoft.EntityFrameworkCore;
using Shop.Application.Interfaces.Context;
using Shop.Ccommon;
using Shop.Ccommon.Dto;

namespace Shop.Application.Services.Product.Queries.GetProductForAdmin
{
    public class GetProductForAdminService : IGetProductForAdminService
    {
        private readonly IDataBaseContext _context;
        public GetProductForAdminService(IDataBaseContext context)
        {
            _context = context;
        }
        public async Task<ResultDto<ProductForAdminDto>> ExecuteAsync(int Page = 1, int PageSize = 20)
        {
            int rowCount = 0;
            var products = await _context.Products
                .Include(x => x.Category)
                .ToPaged(Page, PageSize, out rowCount)
                .Select(x => new ProductsForAdminList_Dto
                {
                    Id = x.Id,
                    Brand = x.Brand,
                    Category = x.Category.Name,
                    Description = x.Description,
                    Displayed = x.Displayed,
                    Inventory = x.Inventory,
                    Name = x.Name,
                    Price = x.Price
                }).ToListAsync();
            return new ResultDto<ProductForAdminDto>
            {
                Data = new ProductForAdminDto
                {
                    CurrentPage = Page,
                    Products = products,
                    PageSize = PageSize,
                    RowCount = rowCount
                },
                IsSuccess = true,
                Message = ""
            };
        }
    }
}
