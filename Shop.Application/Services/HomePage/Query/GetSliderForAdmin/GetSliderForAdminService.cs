using Microsoft.EntityFrameworkCore;
using Shop.Application.Interfaces.Context;
using Shop.Ccommon;
using Shop.Ccommon.Dto;

namespace Shop.Application.Services.HomePage.Query.GetSliderForAdmin
{
    public class GetSliderForAdminService : IGetSliderForAdmin
    {
        private readonly IDataBaseContext _context;
        public GetSliderForAdminService(IDataBaseContext context)
        {
            _context = context;
        }
        public async Task<ResultDto<ResultGetSliderForAdmin>> ExecuteAsync(int page = 1, int pagesize = 10)
        {
            try
            {
                int rowCount = 0;
                var result = await _context.Sliders.ToPaged(page, pagesize, out rowCount).Select(x => new GetSliderForAdminDto
                {
                    ClickCount = x.ClickCount,
                    Src = x.Src,
                    Text = x.Text,
                    Title = x.Title,
                    rowCount = rowCount,
                    Id = x.Id
                }).ToListAsync();
                return new ResultDto<ResultGetSliderForAdmin>
                {
                    Data = new ResultGetSliderForAdmin
                    {
                        Sliders = result,
                        Page = page,
                        PageSize = pagesize,
                        RowsCount = rowCount,
                    },
                    IsSuccess = true,
                    Message = ""
                };
            }
            catch (Exception e)
            {
                return new ResultDto<ResultGetSliderForAdmin>
                {
                    Data = null,
                    IsSuccess = false,
                    Message = e.Message
                };
            }
      
        }


    }
}
