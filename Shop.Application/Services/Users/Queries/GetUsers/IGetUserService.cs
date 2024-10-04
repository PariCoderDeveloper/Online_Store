using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Services.Users.Queries.GetUsers
{
    public interface IGetUserService
    {
        Task<ResultGetUserDto> ExecuteAsync(string SearchKey, int Page = 1, int PageSize = 10);
    }
}
