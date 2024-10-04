using Microsoft.EntityFrameworkCore;
using Shop.Ccommon.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Services.Product.Command.RemoveProduct
{
    public interface IRemoveProduct
    {
        Task<ResultDto> ExecuteAsync(long ProductId);
    }
}
