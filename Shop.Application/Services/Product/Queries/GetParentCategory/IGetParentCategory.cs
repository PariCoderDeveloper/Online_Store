using Shop.Ccommon.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Services.Product.Queries.GetParentCategory
{
    public interface IGetParentCategoryService
    {
        Task<ResultDto<GetParentCategoryResultDto>> ExecuteAsync();
    }
}
