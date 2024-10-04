using Shop.Ccommon.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Services.HomePage.Query.GetSliders
{
    public interface IGetSliders
    {
        Task<ResultDto<List<GetSliderDto>>> ExecuteAsync();
    }
}
