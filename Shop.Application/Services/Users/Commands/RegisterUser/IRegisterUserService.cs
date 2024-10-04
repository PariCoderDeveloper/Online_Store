using Shop.Ccommon.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Services.Users.Commands.RegisterUser
{
    public interface IRegisterUserService
    {
         ResultDto<RegisterUserDto> Execute(RequestRegisterUserDto request);
    }
}
