using Microsoft.EntityFrameworkCore;
using Shop.Application.Interfaces.Context;
using Shop.Ccommon.Dto;

namespace Shop.Application.Services.Product.Queries.GetParentCategory
{
    public class GetParentCategoryService : IGetParentCategoryService
    {
        private readonly IDataBaseContext _context;
        public GetParentCategoryService(IDataBaseContext context)
        {
            _context = context;
        }
        public async Task<ResultDto<GetParentCategoryResultDto>> ExecuteAsync()
        {
            var categories =await _context.Category.Where(x => x.ParentCategoryId == null)
                .Select(x => new GetParentCategoryDto
                {
                   CatId = x.Id,
                   ParentName = x.Name
                })
               .ToListAsync();
            return new ResultDto<GetParentCategoryResultDto>
            {
                Data = new GetParentCategoryResultDto
                {
                    Categories = categories
                },
                IsSuccess = true,
                Message = ""
            };
        }
    }
}
