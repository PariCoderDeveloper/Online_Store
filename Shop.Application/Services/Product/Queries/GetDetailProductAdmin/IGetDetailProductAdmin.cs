using Shop.Application.Services.Product.Queries.GetProductForAdmin;
using Shop.Ccommon.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Services.Product.Queries.GetDetailProductAdmin
{
    public interface IGetDetailProductAdminService
    {
        Task<ResultDto<ProductDetailForAdminDto>> ExecuteAsync(long Id);
    }
}
