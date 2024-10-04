using Shop.Ccommon.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Services.Product.Queries.GetDetailProductForSite
{
    public interface IGetDetailProductForSite
    {
        Task<ResultDto<ProductDetailForSiteDto>> ExecuteAsync(long Id);
    }
}
