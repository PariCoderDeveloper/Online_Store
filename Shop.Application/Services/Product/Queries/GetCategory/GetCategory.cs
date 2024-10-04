using Microsoft.EntityFrameworkCore;
using Shop.Application.Interfaces.Context;
using Shop.Ccommon;
using Shop.Ccommon.Dto;

namespace Shop.Application.Services.Product.Queries.GetCategory
{
    public class GetCategory : IGetCtegory
    {
        private readonly IDataBaseContext _context;
        public GetCategory(IDataBaseContext context)
        {
            _context = context;
        }
        public async Task<ResultDto<CategoriesDto>> ExecuteAsync(long? parentId , int Page = 1, int PageSize = 20)
        {
            int rowCount = 0;
            var categories = await _context.Category
                .Include(p => p.ParentCategory)
                .Include(p => p.SubCategory)
                .Where(p => p.ParentCategoryId == parentId)
                .ToPaged(Page,PageSize,out rowCount)
                .Select(p => new CategoriesListDto
                {
                     Id = p.Id,
                     Name = p.Name,
                     HasChild = p.SubCategory.Count() > 0 ? true : false,
                     Parent = p.ParentCategory != null ? new ParentCategoryDto
                     {
                         Id = p.ParentCategory.Id,
                         Name = p.ParentCategory.Name
                     }:null
                })
                .ToListAsync();

            return new ResultDto<CategoriesDto>
            {
                Data = new CategoriesDto
                {
                    categories = categories,
                    CurrentPage = Page,
                    PageSize = PageSize,
                    RowCount = rowCount
                },
                IsSuccess = true,
                Message = ""
            };
        }
    }
}
