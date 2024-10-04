using Microsoft.EntityFrameworkCore;
using Shop.Application.Interfaces.Context;
using Shop.Ccommon.Dto;

namespace Shop.Application.Services.HomePage.Query.GetSliders
{
    public class GetSliders : IGetSliders
    {
        private readonly IDataBaseContext _context;
        public GetSliders(IDataBaseContext context)
        {
            _context = context;
        }
        public async Task<ResultDto<List<GetSliderDto>>> ExecuteAsync()
        {
            var sliders = await _context.Sliders.Select(x => new GetSliderDto
            {
                Link = x.Link,
                Src = x.Src,
                SubTitle = x.SubTitle,
                Title = x.Title,
                Text = x.Text
            }).ToListAsync();

            return new ResultDto<List<GetSliderDto>>
            {
                Data = sliders,
                IsSuccess = true,
                Message = ""
            };
        }
    }
}
