using Shop.Ccommon.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Services.HomePage.Query.GetSliderForAdmin
{
    public interface IGetSliderForAdmin
    {
        Task<ResultDto<ResultGetSliderForAdmin>> ExecuteAsync(int page = 1, int pagesize = 10);
    }
}
