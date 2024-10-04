using Shop.Ccommon.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Services.Product.Queries.GetProductForSite
{
    public interface IGetProductForSiteService
    {
        Task<ResultDto<ResultGetProductForSiteDto>> ExecuteAsync(int PageSize  ,int Page = 1, long? CatId = null 
            , string? SearchKey = null , Order orderby = 0);
    }

    public enum Order
    {
        menu_order = 0,
        popularity = 1,
        rating = 2,
        date = 3,
        price = 4,
        price_desc = 5
    }
}
