using FluentValidation;

namespace Shop.Presentation.ViewModels.AuthenticationViewModel
{
    public class SignupViewModel
    {
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string RePassword { get; set; }
    }

    public class SignupViewModelValidator : AbstractValidator<SignupViewModel>
    {
        public SignupViewModelValidator()
        {
            RuleFor(x => x.Fullname)
                .NotNull()
                .WithMessage("نام و نام خانوادگی نمیتواند بدون مقدار باشد")
                .NotEmpty()
                .WithMessage("نام و نام خانوادگی نمیتواند خالی باشد")
                .Length(2, 255)
                .WithMessage("نام و نام خانوداگی باید بین 2 تا 255 کاراکتر باشد");

            RuleFor(x => x.Email)
                .NotNull()
                .WithMessage("پست الکترونیک نمیتواند بدون مقدار باشد")
                .NotEmpty()
                .WithMessage("پست الکترونیک نمیتواند خالی باشد")
                .EmailAddress()
                .WithMessage("لطفا ایمیل را به درستی وارد نمایید");

            RuleFor(x => x.Password)
                .NotNull()
                .WithMessage("رمزعبور نمیتواند بدون مقدار باشد")
                .NotEmpty()
                .WithMessage("لطفا کلمه عبور را وارد نمایید");

            RuleFor(x => x.RePassword)
                .Equal(x => x.Password)
                .WithMessage("کلمه عبور و تأیید کلمه عبور یکسان نیستند");
        }
    }
}
