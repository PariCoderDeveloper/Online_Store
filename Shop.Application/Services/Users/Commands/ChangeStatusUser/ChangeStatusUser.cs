using Shop.Application.Interfaces.Context;
using Shop.Ccommon.Dto;

namespace Shop.Application.Services.Users.Commands.ChangeStatusUser
{
    public class ChangeStatusUser : IChangeStatusUser
    {
        private readonly IDataBaseContext _context;
        public ChangeStatusUser(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(long UserId)
        {
            try
            {
                var user = _context.Users.Find(UserId);
                if (user == null)
                {
                    return new ResultDto
                    {
                        IsSuccess = false,
                        Message = "کاربری با این ایدی پیدا نشد"
                    };
                }
                user.IsActive = !user.IsActive;
                _context.SaveChanges();
                string userState = user.IsActive == true ? "غیرفعال" : "فعال";
                return new ResultDto
                {
                    IsSuccess = true,
                    Message = $"کاربر با موفقیت {userState} شد"
                };
            }
            catch (Exception)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "خطایی رخ داد"
                };
            }
        }
    }
}
