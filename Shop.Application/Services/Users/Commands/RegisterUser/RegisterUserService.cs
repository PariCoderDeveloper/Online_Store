using Bugeto_Store.Common;
using Shop.Application.Interfaces.Context;
using Shop.Ccommon.Dto;
using Shop.Domain.Entities.Users;
using System.Text.RegularExpressions;

namespace Shop.Application.Services.Users.Commands.RegisterUser
{
    public class RegisterUserService : IRegisterUserService
    {
        private readonly IDataBaseContext _context;
        public RegisterUserService(IDataBaseContext context)
        {
            _context = context;
        }
        
        public ResultDto<RegisterUserDto> Execute(RequestRegisterUserDto request)
        {
            try
            {
                // VALIDATION
                if (string.IsNullOrWhiteSpace(request.FullName))
                {
                    return new ResultDto<RegisterUserDto>
                    {
                        Data = new RegisterUserDto
                        {
                            UserId = 0
                        },
                        IsSuccess = false,
                        Message = "لطفا نام و نام خانوادگی کاربر را وارد نمایید"
                    };
                }

                if (string.IsNullOrWhiteSpace(request.Email))
                {
                    return new ResultDto<RegisterUserDto>
                    {
                        Data = new RegisterUserDto
                        {
                            UserId = 0
                        },
                        IsSuccess = false,
                        Message = "لطفا ایمیل را وارد نمایید"
                    };
                }
                string emailRegex = @"^[a-zA-Z0-9.!#$%&'*++/=?^_`{|}~-]+@[a-zA-Z0-9.-]+\.[A-Z]{2,}$";
                var match = Regex.Match(request.Email, emailRegex, RegexOptions.IgnoreCase);
                if (!match.Success)
                {
                    return new ResultDto<RegisterUserDto>()
                    {
                        Data = new RegisterUserDto
                        {
                            UserId = 0
                        },
                        IsSuccess = true,
                        Message = "فرمت پست الکترونیک به درستی وارد نشده است"
                    };
                }
                if (string.IsNullOrWhiteSpace(request.Password))
                {
                    return new ResultDto<RegisterUserDto>
                    {
                        Data = new RegisterUserDto
                        {
                            UserId = 0
                        },
                        IsSuccess = false,
                        Message = "لطفا رمز عبور را وارد نمایید"
                    };
                }

                if (request.Password != request.RePassword)
                {
                    return new ResultDto<RegisterUserDto>
                    {
                        Data = new RegisterUserDto
                        {
                            UserId = 0
                        },
                        Message = "رمز عبور با تکرار آن برابر نیست",
                        IsSuccess = false
                    };
                }
                
                var passwordHasher = new PasswordHasher();
                var HashedPassword = passwordHasher.HashPassword(request.Password);

                User user = new User
                {
                    Email = request.Email,
                    Fullname = request.FullName,
                    PasswordHash = HashedPassword,
                    IsActive = true
                };

                List<UserInRole> UserInRole = new List<UserInRole>();
                foreach (var item in request.Roles)
                {
                    var roles = _context.Roles.Find(item.Id);
                    UserInRole.Add(new UserInRole
                    {
                        Role = roles,
                        RoleId = roles.Id,
                        User = user,
                        UserId = user.Id
                    });

                }
                user.UserInRoles = UserInRole;
                _context.Users.Add(user);
                _context.SaveChanges();
                return new ResultDto<RegisterUserDto>()
                {
                    Data = new RegisterUserDto
                    {
                        UserId = user.Id
                    },
                    IsSuccess = true,
                    Message = "ثبت کاربر با موفقیت انجام شد"
                };
            }
            catch (Exception)
            {
                return new ResultDto<RegisterUserDto>
                {
                    IsSuccess = false,
                    Message = "فرآیند ثبت نام با خطا مواجه شد"
                };
            }
           
        }
    }
}
