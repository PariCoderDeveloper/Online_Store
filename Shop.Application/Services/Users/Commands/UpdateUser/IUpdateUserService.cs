using Shop.Ccommon.Dto;
using Shop.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Services.Users.Commands.UpdateUser
{
    public interface IUpdateUserService
    {
        ResultDto Execute(RequestEditDto request);
    }
}
