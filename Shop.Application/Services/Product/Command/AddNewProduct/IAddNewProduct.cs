using Shop.Ccommon.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Domain.Entities;
using Shop.Domain.Commen;

namespace Shop.Application.Services.Product.Command.AddNewProduct
{
    public interface IAddNewProduct
    {
        Task<ResultDto> ExecuteAsync(AddProductDto product);
    }
}
