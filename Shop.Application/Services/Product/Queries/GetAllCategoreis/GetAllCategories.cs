using Microsoft.EntityFrameworkCore;
using Shop.Application.Interfaces.Context;
using Shop.Ccommon.Dto;

namespace Shop.Application.Services.Product.Queries.GetAllCategoreis
{
    public class GetAllCategories : IGetAllCategories
    {
        private readonly IDataBaseContext _context;
        public GetAllCategories(IDataBaseContext context)
        {
            _context = context;
        }
        public async Task<ResultDto<List<AllCategoriesDto>>> ExecuteAsync()
        {
            try
            {
                var categoreis = await _context.Category
               .Include(p => p.ParentCategory)
               .Include(p => p.SubCategory)
               .Select(p => new AllCategoriesDto
               {
                   Id = p.Id,
                   Name = p.ParentCategoryId != null ? $"{p.ParentCategory.Name} - {p.Name}" : p.Name
               }).ToListAsync(); 
                return new ResultDto<List<AllCategoriesDto>>
                {
                    Data = categoreis,
                    IsSuccess = true,
                    Message = "با موفقیت بازگشت داده شد."
                };
            }
            catch (Exception e)
            {

                return new ResultDto<List<AllCategoriesDto>>
                {
                    Data = null,
                    Message = e.Message,
                    IsSuccess = false
                };
            }
           
        }
    }
}
