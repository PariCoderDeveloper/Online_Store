using FluentValidation;
using Shop.Application.Services.Users.Commands.LoginUser;

namespace Shop.Application.Validations
{
    public class RequestLoginValidator : AbstractValidator<RequestLoginDto>
    {
        public RequestLoginValidator()
        {
            RuleFor(x => x.Email).NotNull().WithMessage("مقدار پست الکترونیک نمیتواند بدون مقدار باشد")
                .NotEmpty().WithMessage("مقدار پست الکترونیک نمیتواند خالی باشد")
                .EmailAddress().WithMessage("فرمت پست الکترونیک وارد شده صحیح نیست");

            RuleFor(x => x.Password).NotNull().WithMessage("مقدار گذرواژه نمیتواند بدون مقدار باشد")
                .NotEmpty().WithMessage("مقدار گذرواژه نمیتواند خالی باشد");
        }
    }
}
