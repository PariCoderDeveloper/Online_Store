using Microsoft.EntityFrameworkCore;
using Shop.Application.Interfaces.Context;
using Shop.Ccommon.Dto;

namespace Shop.Application.Services.Product.Queries.GetDetailProductForSite
{
    public class GetDetailProductForSite : IGetDetailProductForSite
    {
        private readonly IDataBaseContext _context;
        public GetDetailProductForSite(IDataBaseContext context)
        {
            _context = context;
        }
        public async Task<ResultDto<ProductDetailForSiteDto>> ExecuteAsync(long Id)
        {
            var productEntity = await _context.Products.FindAsync(Id);          

            if (productEntity == null)
            {
                return new ResultDto<ProductDetailForSiteDto>
                {
                    Data = null,
                    IsSuccess = false,
                    Message = "محصول مورد نظر پیدا نشد"
                };
            }
            productEntity.VisitCount += 1;
            await _context.SaveChangesAsync();

            var product = await _context.Products
                .Include(x => x.Category)
                .ThenInclude(x => x.ParentCategory)
                .Include(x => x.ProductImages)
                .Include(x => x.ProductFeatures)
                .Where(x => x.Id == Id)
                .Select(x => new ProductDetailForSiteDto
                {
                    Id = x.Id,
                    Title = x.Name,
                    Brand = x.Brand,
                    Category = $"{(x.Category.ParentCategory != null ? x.Category.ParentCategory.Name + '-' : "")} {x.Category.Name}",
                    Description = x.Description,
                    Inventory = x.Inventory,
                    Price = x.Price,
                    ImageSrc = x.ProductImages.Select(x => x.Src).ToList(),
                    Features = x.ProductFeatures.Select(x => new ProductDetailForSite_FeatureDto
                    {
                        DisplayText = x.DisplayName,
                        Value = x.Value
                    }).ToList()
                    ,VisitedCount = x.VisitCount
                }).FirstOrDefaultAsync();

           
            return new ResultDto<ProductDetailForSiteDto>
            {
                Data = product,
                IsSuccess = true,
                Message = ""
            };
        }
    }
}
