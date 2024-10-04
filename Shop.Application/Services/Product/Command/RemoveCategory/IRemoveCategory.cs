using Shop.Ccommon.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Services.Product.Command.RemoveCategory
{
    public interface IRemoveCategory
    {
        ResultDto Execute(long Id);
    }
}
