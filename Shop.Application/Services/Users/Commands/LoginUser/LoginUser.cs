using Bugeto_Store.Common;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Interfaces.Context;
using Shop.Ccommon.Dto;

namespace Shop.Application.Services.Users.Commands.LoginUser
{
    public class LoginUser : ILoginUser
    {
        private readonly IDataBaseContext _context;
        public LoginUser(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto<LoginUserDto> Execute(RequestLoginDto request)
        {
            if (string.IsNullOrEmpty(request.Email))
            {
                return new ResultDto<LoginUserDto>
                {
                    Data = new LoginUserDto
                    {

                    },
                    IsSuccess = false,
                    Message = "پست الکترونیک نمیتواند خالی باشد."
                };
            }
            if (string.IsNullOrWhiteSpace(request.Password))
            {
                return new ResultDto<LoginUserDto>
                {
                    Data = new LoginUserDto
                    {

                    },
                    IsSuccess = false,
                    Message = " گذرواژه نمیتواند خالی باشد."
                };
            }

            var user = _context.Users.Include(x => x.UserInRoles)
                .ThenInclude(x => x.Role)
                .Where(x => x.Email.Equals(request.Email.ToString())
                && x.IsActive == true).FirstOrDefault();
            if (user == null)
            {
                return new ResultDto<LoginUserDto>
                {
                    Data = new LoginUserDto
                    {

                    },
                    IsSuccess = false,
                    Message = "کاربری با این پست الکترونیک در سایت ثبت نام نکرده است"
                };
            }

            var passwordHasher = new PasswordHasher();
            bool resultVarifyPassword = passwordHasher.VerifyPassword(user.PasswordHash, request.Password);
            if (resultVarifyPassword == false)
            {
                return new ResultDto<LoginUserDto>
                {
                    Data = new LoginUserDto
                    {

                    },
                    IsSuccess = false,
                    Message = "رمز عبور وارد شده صحیح نیست"
                };
            }
            var roles = "";
            foreach (var item in user.UserInRoles)
            {
                roles += $"{item.Role.Name}";
            }
            return new ResultDto<LoginUserDto>
            {
                Data = new LoginUserDto
                {
                    Fullname = user.Fullname,
                    Roles = roles,
                    UserId = user.Id
                },
                IsSuccess = true,
                Message = "ورود به سایت با موفقیت انجام شد"
            };
        }
    }
}
