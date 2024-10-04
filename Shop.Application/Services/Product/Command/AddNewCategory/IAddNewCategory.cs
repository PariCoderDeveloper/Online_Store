using Shop.Ccommon.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Services.Product.Command.AddNewCategory
{
    public interface IAddNewCategory
    {
        ResultDto Execute(long? ParentId , string Name);
    }
}