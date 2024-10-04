using Shop.Ccommon.Dto;
using Shop.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Services.Users.Queries.GetRole
{
    public interface IGetRolesService
    {
        ResultDto<List<RoleDto>> Execute();
    }
}
