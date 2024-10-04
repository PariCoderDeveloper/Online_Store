using FluentValidation;
using Shop.Application.Services.Product.Command.AddNewProduct;

namespace Shop.Application.Validations
{
    public class AddProductDtoValidation : AbstractValidator<AddProductDto>
    {
        public AddProductDtoValidation()
        {
            RuleFor(x => x.Name)
                .NotNull()
                .WithMessage("نام محصول نمیتواند بدون مقدار باشد")
                .NotEmpty()
                .WithMessage("نام محصول نمیتواند خالی باشد");

            RuleFor(x => x.Brand)
                .NotNull()
                .WithMessage("برند نمیتواند بدون مقدار باشد")
                .NotEmpty()
                .WithMessage("برند نمیتواند خالی باشد");

            RuleFor(x => x.Description)
                .NotNull()
                .WithMessage("درباره محصول نمیتواند بدون مقدار باشد")
                .NotEmpty()
                .WithMessage("لطفا درباره محصول  را وارد نمایید");

            RuleFor(x => x.Price)
               .NotNull()
                .WithMessage("قیمت محصول نمیتواند بدون مقدار باشد")
                .NotEmpty()
                .WithMessage("لطفا قیمت محصول را وارد نمایید");

            RuleFor(x => x.Inventory)
              .NotNull()
               .WithMessage("موجوی محصول بدون مقدار باشد")
               .NotEmpty()
               .WithMessage("لطفا موجودی محصول را وارد نمایید");

        }
    }

}
