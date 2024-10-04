using FluentValidation;
using Shop.Application.Services.Users.Commands.UpdateUser;

namespace Shop.Application.Validations
{
    public class RequestEditDtoValidator : AbstractValidator<RequestEditDto>
    {
        public RequestEditDtoValidator()
        {
            RuleFor(x => x.UserId)
                .NotNull()
                .WithMessage("آیدی کاربر نمیتواند بدون مقدار باشد")
                .NotEmpty()
                .WithMessage("آیدی کاربر نمیتواند خالی باشد");

            RuleFor(x => x.Fullname)
                .NotNull()
                .WithMessage("نام کامل کاربر نمیتواند بدون مقدار باشد")
                .NotEmpty()
                .WithMessage("نام کامل کاربر نمیتواند خالی باشد")
                .Length(2, 255)
                .WithMessage("نام کامل کاربر باید بین 2 تا 255 کاراکتر باشد");

            RuleFor(x => x.Email)
              .NotNull()
              .WithMessage("پست الکترونیک کاربر نمیتواند بدون مقدار باشد")
              .NotEmpty()
              .WithMessage("پست الکترونیک کاربر نمیتواند خالی باشد")
              .EmailAddress()
              .WithMessage("فرمت پست الکترونیک باید به صورت صحیح وارد شود");

            RuleFor(x => x.PasswordHash)
             .NotNull()
             .WithMessage("رمزعبور کاربر نمیتواند بدون مقدار باشد")
             .NotEmpty()
             .WithMessage("رمزعبور کاربر نمیتواند خالی باشد");
        }
    }

}
