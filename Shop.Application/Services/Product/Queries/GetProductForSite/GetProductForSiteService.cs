using Microsoft.EntityFrameworkCore;
using Shop.Application.Interfaces.Context;
using Shop.Ccommon;
using Shop.Ccommon.Dto;

namespace Shop.Application.Services.Product.Queries.GetProductForSite
{
    public class GetProductForSiteService : IGetProductForSiteService
    {
        private readonly IDataBaseContext _context;
        public GetProductForSiteService(IDataBaseContext context)
        {
            _context = context;
        }
        public async Task<ResultDto<ResultGetProductForSiteDto>> ExecuteAsync(int PgeSize = 8, int Page = 1, long? CatId = null
            , string? SearchKey = null, Order orderby = 0)
        {
            int TotalRow = 0;
            Random rd = new Random();
            var productsQuery = _context.Products
                .Include(x => x.Category)
                .ThenInclude(x => x.ParentCategory)
                .AsQueryable();
            if (CatId != null)
            {
                productsQuery = productsQuery.Where(x => x.CategoryId == CatId).AsQueryable();
            }

            if (!string.IsNullOrWhiteSpace(SearchKey))
            {
                productsQuery = productsQuery.Where(x => x.Name.Contains(SearchKey) ||
                            x.Brand.Contains(SearchKey)).AsQueryable();
            }

            switch (orderby)
            {
                case Order.menu_order:
                    productsQuery = productsQuery.OrderByDescending(x => x.Id).AsQueryable();
                    break;
                case Order.popularity:
                    productsQuery = productsQuery.OrderByDescending(x => x.VisitCount).AsQueryable();
                    break;
                case Order.rating:
                    break;
                case Order.date:
                    productsQuery = productsQuery.OrderByDescending(x => x.InsertTime).AsQueryable();
                    break;
                case Order.price:
                    productsQuery = productsQuery.OrderBy(x => x.Price).AsQueryable();
                    break;
                case Order.price_desc:
                    productsQuery = productsQuery.OrderByDescending(x => x.Price).AsQueryable();
                    break;
                default:
                    break;
            }

            var products = await productsQuery.Include(x => x.ProductImages)
                 .ToPaged(Page, PgeSize, out TotalRow)
                .Select(x => new GetProductForSiteDto
                {
                    Brand = x.Brand,
                    Id = x.Id,
                    Name = x.Name,
                    Price = x.Price,
                    Category = $"{x.Category.ParentCategory.Name ?? ""} {x.Category.Name}",
                    ImageSrc = x.ProductImages.FirstOrDefault().Src,
                    Star = rd.Next(1, 5)
                }).ToListAsync();
            return new ResultDto<ResultGetProductForSiteDto>
            {
                Data = new ResultGetProductForSiteDto
                {
                    Products = products,
                    TotalRow = TotalRow
                },
                IsSuccess = true,
                Message = ""
            };
        }
    }
}
