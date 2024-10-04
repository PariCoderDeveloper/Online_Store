using Shop.Application.Interfaces.Context;
using Shop.Application.Services.HomePage.Cammand.AddNewSliderService;
using Shop.Ccommon.Dto;
using Shop.Domain.Entities.HomePage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Services.HomePage.Query.GetSliderWithId
{
    public interface IGetSliderWithId
    {
        Task<ResultDto<AddNewSliderDto>> ExecuteAsync(long? Id);
    }

    public class GetSliderWithId : IGetSliderWithId
    {
        private readonly IDataBaseContext _context;
        public GetSliderWithId(IDataBaseContext context)
        {
            _context = context;
        }
        public async Task<ResultDto<AddNewSliderDto>> ExecuteAsync(long? Id)
        {
            var result = _context.Sliders.Find(Id);
            return new ResultDto<AddNewSliderDto>
            {
                Data = new AddNewSliderDto
                {
                    Title = result.Title,
                    Display = result.Display,
                    Link = result.Link,
                    SubTitle = result.SubTitle,
                    Text = result.Text,
                    Id = result.Id,
                },
                IsSuccess = true,
                Message = ""
            };
        }
    }

}
