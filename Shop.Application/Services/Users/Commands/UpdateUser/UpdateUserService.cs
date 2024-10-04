using Bugeto_Store.Common;
using Shop.Application.Interfaces.Context;
using Shop.Ccommon.Dto;
using Shop.Domain.Entities.Users;

namespace Shop.Application.Services.Users.Commands.UpdateUser
{
    public class UpdateUserService : IUpdateUserService
    {
        private readonly IDataBaseContext _context;
        public UpdateUserService(IDataBaseContext context)
        {
            _context = context;
        }

        public ResultDto Execute(RequestEditDto request)
        {
            var user = _context.Users.Find(request.UserId);
            if (user == null) 
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "کاربر یافت نشد"
                };
            }
            var passwordHaher = new PasswordHasher();
            var HashedPassword = passwordHaher.HashPassword(request.PasswordHash);
            user.Fullname = request.Fullname;
            user.Email = request.Email;
            user.PasswordHash = HashedPassword;
            _context.SaveChanges();
            return new ResultDto
            {
                IsSuccess = true,
                Message = "به روزرسانی با موفقیت انجام شد"
            };
        }
    }
}
