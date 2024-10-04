using FluentValidation;
using Shop.Application.Services.Product.Command.AddNewProduct;
using Shop.Application.Services.Users.Commands.LoginUser;
using Shop.Application.Services.Users.Commands.UpdateUser;
using Shop.Application.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Interfaces.FacadPattern
{
    public interface IValidationFacad
    {
        Task RequestEditDtoValidator(RequestEditDto model);
        Task RequestLoginValidator(RequestLoginDto model);
        Task AddProductDtoValidation(AddProductDto model);
    }
}
