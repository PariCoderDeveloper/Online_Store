using Microsoft.EntityFrameworkCore;
using Shop.Application.Interfaces.Context;
using Shop.Ccommon.Dto;
using Shop.Domain.Entities.Product;

namespace Shop.Application.Services.Product.Queries.GetDetailProductAdmin
{
    public class GetDetailProductAdmin : IGetDetailProductAdminService
    {
        private readonly IDataBaseContext _context;
        public GetDetailProductAdmin(IDataBaseContext context)
        {
            _context = context;
        }
        public async Task<ResultDto<ProductDetailForAdminDto>> ExecuteAsync(long Id)
        {
            var product = await _context.Products
                .Include(x => x.Category)
                .ThenInclude(p => p.ParentCategory)
                .Include(x => x.ProductFeatures)
                .Include(x => x.ProductImages)
                .Where(x => x.Id == Id)
                .FirstOrDefaultAsync();
            return new ResultDto<ProductDetailForAdminDto>
            {
                Data = new ProductDetailForAdminDto()
                {
                    Brand = product.Brand,
                    Category = GetCategory(product.Category),
                    Description = product.Description,
                    Displayed = product.Displayed,
                    Id = product.Id,
                    Inventory = product.Inventory,
                    Name = product.Name,
                    Price = product.Price,
                    VisitedCount = product.VisitCount,
                    productImages = product.ProductImages.ToList().Select(x => new ProductDetailImageDto
                    {
                        Id = x.Id,
                        Src = x.Src
                    }).ToList(),
                    productFeatures = product.ProductFeatures.ToList().Select(x => new ProductDetailFeatureDto
                    {
                        Id = x.Id,
                        DisplayName = x.DisplayName,
                        Value = x.Value
                    }).ToList(),
                },
                IsSuccess = true,
                Message = ""
            };
        }

        private string GetCategory(Category category)
        {
            string result = category.ParentCategory != null ? $"{category.ParentCategory.Name} - " : "";
            return result += category.Name;
        }
    }
}
