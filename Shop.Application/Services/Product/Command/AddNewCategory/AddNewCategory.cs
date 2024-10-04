using Shop.Application.Interfaces.Context;
using Shop.Ccommon.Dto;
using Shop.Domain.Entities.Product;

namespace Shop.Application.Services.Product.Command.AddNewCategory
{
    public class AddNewCategory : IAddNewCategory
    {
        private readonly IDataBaseContext _context;
        public AddNewCategory(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(long? ParentId, string Name)
        {
            if (string.IsNullOrEmpty(Name))
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "نام دسته بندی را وارد نمائید"
                };
            }
            Category category = new Category() { 
               Name = Name,
               ParentCategory = GetParent(ParentId)
            };
            _context.Category.Add(category);
            _context.SaveChanges();
            return new ResultDto
            {
                IsSuccess = true,
                Message = "دسته بندی با موفقیت انجام شد"
            };
        }

        private Category GetParent(long? parentid)
        {
           return _context.Category.Find(parentid);
        }
    }
}