using Shop.Ccommon.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Services.Commen.Query.GetMenuService
{
    public interface IGetMenuService
    {
       ResultDto<List<MenuServiceDto>> Execute();
    }
}
