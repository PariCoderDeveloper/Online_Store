//using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Internal;
using Shop.Application.Services.Users.Commands.ChangeStatusUser;
using Shop.Application.Services.Users.Commands.RegisterUser;
using Shop.Application.Services.Users.Commands.RemoveUser;
using Shop.Application.Services.Users.Commands.UpdateUser;
using Shop.Application.Services.Users.Queries.GetRole;
using Shop.Application.Services.Users.Queries.GetUsers;
using Shop.Ccommon.Dto;
using Shop.Domain.Entities.Users;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;

namespace Shop.Presentation.Areas.Admin.Controllers
{
    public class PanelController : Controller
    {
        private readonly IGetUserService _getUserService;
        private readonly IGetRolesService _getRolesService;
        private readonly IRegisterUserService _registerUserServices;
        private readonly IRemoveUserService _removeUserService;
        private readonly IUpdateUserService _updateUserService;
        private readonly IChangeStatusUser _changeStatusUser;
        //private readonly IValidator<RequestEditDto> _validator;
        public PanelController(IGetUserService getUserService, IGetRolesService getRolesService
            , IRegisterUserService registerUserServices,IRemoveUserService removeUserService,
            IUpdateUserService updateUserService , IChangeStatusUser changeStatusUser)
           // IValidator<RequestEditDto> validator)
        {
            _getUserService = getUserService;
            _getRolesService = getRolesService;
            _registerUserServices = registerUserServices;
            _removeUserService = removeUserService;
            _updateUserService = updateUserService;
            _changeStatusUser = changeStatusUser;
           // _validator = validator;
        }

        public async Task<IActionResult> Index(string searchkey, int page = 1,int PageSize = 10)
        {
            try
            {
                var result = await _getUserService.ExecuteAsync(searchkey , page , PageSize);


                return View("~/Areas/Admin/Views/Panel/Index.cshtml", result);
            }
            catch (Exception e)
            {
                return View("~/Areas/Admin/Views/Panel/Index.cshtml", e);
            }

        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Roles = new SelectList(_getRolesService.Execute().Data, "Id", "Name");
            return View("~/Areas/Admin/Views/Panel/Create.cshtml");
        }

        [HttpPost]
        public IActionResult Create(string Email, string Fullname, long RoleId, string Password, 
            string RePassword)
        {
            var result = _registerUserServices.Execute(new RequestRegisterUserDto
            {
                Email = Email,
                FullName = Fullname,
                Roles = new List<RoleInRegisterUserDto>
                {
                   new RoleInRegisterUserDto
                   {
                       Id = RoleId
                   }
                },
                Password = Password,
                RePassword = RePassword

            });
            return Json(result);
        }

        [HttpPost]
        public IActionResult Delete(long UserId)
        {
            return Json(_removeUserService.Execute(UserId));
        }
        [HttpPost]
        public IActionResult Update(int UserId, string Fullname, string Email, string PasswordHash)
        {
            //ValidationResult validationResult = _validator.Validate(new RequestEditDto
            //{
            //    Email = Email,
            //    Fullname = Fullname,
            //    PasswordHash = PasswordHash,
            //    UserId = UserId
            //});
            //if (!validationResult.IsValid)
            //{
            //    return Json(new ResultDto
            //    {
            //        IsSuccess = false,
            //        Message = string.Join(" * " , validationResult.Errors.Select(e => e.ErrorMessage))
            //    });
            //}
            return Json(_updateUserService.Execute(new RequestEditDto
            {
                UserId = UserId,
                Fullname = Fullname,
                Email = Email,
                PasswordHash = PasswordHash
            }));
        }

        [HttpPost]
        public IActionResult ChangeStatusUser(long UserId)
        {
            return Json(_changeStatusUser.Execute(UserId));
        }
    }
}
