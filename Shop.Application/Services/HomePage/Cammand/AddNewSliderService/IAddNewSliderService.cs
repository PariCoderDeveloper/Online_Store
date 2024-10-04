using Shop.Ccommon.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Services.HomePage.Cammand.AddNewSliderService
{
    public interface IAddNewSliderService
    {
        Task<ResultDto> ExecuteAsync(AddNewSliderDto request);
    }
}
