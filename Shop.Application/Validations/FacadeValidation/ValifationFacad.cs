using FluentValidation;
using Microsoft.Extensions.Options;
using Shop.Application.Interfaces.FacadPattern;
using Shop.Application.Services.Product.Command.AddNewProduct;
using Shop.Application.Services.Users.Commands.LoginUser;
using Shop.Application.Services.Users.Commands.UpdateUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Validations.FacadeValidation
{
    public class ValifationFacad : IValidationFacad
    {
        private readonly IValidator<RequestEditDto> _requestEditDtoValidator;
        private readonly IValidator<RequestLoginDto> _requestLoginValidator;
        private readonly IValidator<AddProductDto> _addProductDtoValidation;
        public ValifationFacad(IValidator<RequestEditDto> requestEditDtoValidator,
            IValidator<RequestLoginDto> requestLoginValidator,
            IValidator<AddProductDto> addProductDtoValidation)
        {
            _requestEditDtoValidator = requestEditDtoValidator;
            _requestLoginValidator = requestLoginValidator;
            _addProductDtoValidation = addProductDtoValidation;
        }

        public async Task AddProductDtoValidation(AddProductDto model)
        {
            await _addProductDtoValidation.ValidateAndThrowAsync(model);
        }   

        public async Task RequestEditDtoValidator(RequestEditDto model)
        {
            await _requestEditDtoValidator.ValidateAndThrowAsync(model);
        }

        public async Task RequestLoginValidator(RequestLoginDto model)
        {
            await _requestLoginValidator.ValidateAndThrowAsync(model);
        }
    }
}
