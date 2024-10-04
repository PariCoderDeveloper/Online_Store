using Shop.Application.Interfaces.Context;
using Shop.Ccommon.Dto;

namespace Shop.Application.Services.Product.Command.RemoveCategory
{
    public class RemoveCategory : IRemoveCategory
    {
        private readonly IDataBaseContext _context;
        public RemoveCategory(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(long Id)
        {
            var Category = _context.Category.Find(Id);
            if (Category == null)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "دسته بندی موردنظر وجود ندارد"
                };
            }
            Category.RemoveTime = DateTime.Now;
            Category.IsRemoved = true;
            _context.SaveChanges();
            return new ResultDto
            {
                IsSuccess = true,
                Message = "دسته بندی با موفقیت حذف شد"
            };

        }
    }
}
