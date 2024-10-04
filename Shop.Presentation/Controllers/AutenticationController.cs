using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using Shop.Application.Services.Users.Commands.LoginUser;
using Shop.Application.Services.Users.Commands.RegisterUser;
using Shop.Ccommon.Dto;
using Shop.Domain.Entities.Users;
using Shop.Presentation.ViewModels.AuthenticationViewModel;
using System.Security.Claims;

namespace Shop.Presentation.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly IRegisterUserService _registeredServices;
        private readonly ILoginUser _loginUserService;
        private readonly IValidator<SignupViewModel> _validator;
        private readonly IValidator<RequestLoginDto> _loginValidator;
        public AuthenticationController(IRegisterUserService registeredServices,ILoginUser loginUser, IValidator<SignupViewModel> validator
            , IValidator<RequestLoginDto> loginValidator)
        {
            _registeredServices = registeredServices;
            _loginUserService = loginUser;
            _validator = validator;
            _loginValidator = loginValidator;
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View("~/Views/Authentication/SignUp.cshtml");
        }

        [HttpPost]
        public IActionResult SignUp(SignupViewModel request)
        {
            ValidationResult validation = _validator.Validate(request);
            if (!validation.IsValid)
            {
                return Json(new ResultDto
                {
                    IsSuccess = false,
                    Message = string.Join(" * ", validation.Errors.Select(e => e.ErrorMessage))
                });
            }
            var singupResult = _registeredServices.Execute(new RequestRegisterUserDto
            {
                Email = request.Email,
                FullName = request.Fullname,
                Password = request.Password,
                RePassword = request.RePassword,
                Roles = new List<RoleInRegisterUserDto>
                {
                    new RoleInRegisterUserDto
                    {
                        Id = 3
                    }
                }
            });
            if (singupResult.IsSuccess == true)
            {
                var claims = new List<Claim>() {
                new Claim(ClaimTypes.NameIdentifier, singupResult.Data.UserId.ToString()),
                new Claim(ClaimTypes.Email, request.Email),
                new Claim(ClaimTypes.Name, request.Fullname),
                new Claim(ClaimTypes.Role, "Customer")
                };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var princeple = new ClaimsPrincipal(identity);
                var properties = new AuthenticationProperties()
                {
                    IsPersistent = true
                };
                HttpContext.SignInAsync(princeple, properties);
            }


            return Json(new ResultDto
            {
                IsSuccess = true,
                Message = "ثبت‌نام با موفقیت انجام شد"
            });
        }

        [HttpPost]
        public IActionResult Login(string Email, string Password)
        {
            ValidationResult validation = _loginValidator.Validate(new RequestLoginDto
            {
                Email = Email,
                Password = Password
            });
            if (!validation.IsValid)
            {
                return Json(new ResultDto
                {
                    IsSuccess = false,
                    Message = string.Join(" * ", validation.Errors.Select(x => x.ErrorMessage))
                });
            }
            var result = _loginUserService.Execute(new RequestLoginDto
            {
                Email = Email,
                Password = Password
            });
            if (result.IsSuccess == true)
            {
                var claims = new List<Claim>()
                {
                new Claim(ClaimTypes.NameIdentifier,result.Data.UserId.ToString()),
                new Claim(ClaimTypes.Email, Email),
                new Claim(ClaimTypes.Name, result.Data.Fullname),
                new Claim(ClaimTypes.Role, result.Data.Roles ),
            };
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                var properties = new AuthenticationProperties()
                {
                    IsPersistent = true,
                    ExpiresUtc = DateTime.Now.AddDays(5),
                };
                HttpContext.SignInAsync(principal, properties);

            }
            return Json(result);
        }
           
    }
}

