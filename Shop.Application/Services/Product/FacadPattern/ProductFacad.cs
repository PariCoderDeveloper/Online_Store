using Microsoft.AspNetCore.Hosting;
using Shop.Application.Interfaces.Context;
using Shop.Application.Interfaces.FacadPattern;
using Shop.Application.Services.Product.Command.AddNewCategory;
using Shop.Application.Services.Product.Command.AddNewProduct;
using Shop.Application.Services.Product.Command.RemoveCategory;
using Shop.Application.Services.Product.Command.RemoveProduct;
using Shop.Application.Services.Product.Queries.GetAllCategoreis;
using Shop.Application.Services.Product.Queries.GetCategory;
using Shop.Application.Services.Product.Queries.GetDetailProductAdmin;
using Shop.Application.Services.Product.Queries.GetDetailProductForSite;
using Shop.Application.Services.Product.Queries.GetProductForAdmin;
using Shop.Application.Services.Product.Queries.GetProductForSite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Services.Product.FacadPattern
{
    public class ProductFacad : IProductFacad
    {
        private readonly IDataBaseContext _context;
        private readonly IHostingEnvironment _ev;
        public ProductFacad(IDataBaseContext context, IHostingEnvironment ev)
        {
            _context = context;
            _ev = ev;
        }

        // command
        private AddNewCategory _addNewCategory;
        public AddNewCategory NewCategoryService
        {
            get
            {
                return _addNewCategory = _addNewCategory ?? new AddNewCategory(_context);
            }
        }

        // query
        private IGetProductForAdminService _getProductForAdminService;
        public IGetProductForAdminService getProductForAdmin
        {
            get
            {
                return _getProductForAdminService = _getProductForAdminService ?? new GetProductForAdminService(_context);
            }
        }

        // query
        private IGetDetailProductAdminService _getDetailProductAdminService;
        public IGetDetailProductAdminService getDetailProductAdmin
        {
            get
            {
                return _getDetailProductAdminService = _getDetailProductAdminService ?? new GetDetailProductAdmin(_context);
            }
        }

        // command
        private AddNewProduct _addNewProduct;
        public AddNewProduct addNewProductService
        {
            get
            {
                return _addNewProduct = _addNewProduct ?? new AddNewProduct(_context, _ev);
            }
        }

        // query
        private IGetCtegory _getCtegory;
        public IGetCtegory getCtegory
        {
            get
            {
                return _getCtegory = _getCtegory ?? new GetCategory(_context);
            }
        }

        // command
        private RemoveCategory _removeCategory;
        public RemoveCategory RemoveCategory
        {
            get
            {
                return _removeCategory = _removeCategory ?? new RemoveCategory(_context);
            }
        }

        // query
        private IGetAllCategories _getAllCategories;
        public IGetAllCategories getAllCategories
        {
            get
            {
                return _getAllCategories = _getAllCategories ?? new GetAllCategories(_context);
            }
        }

        // query
        private IGetProductForSiteService _getforSiteService;
        public IGetProductForSiteService getProductForSiteService
        {
            get
            {
                return _getforSiteService = _getforSiteService ?? new GetProductForSiteService(_context);
            }
        }
        private RemoveProduct _removeProduct;
        public RemoveProduct RemoveProduct{
            get
            {
                return _removeProduct = _removeProduct ?? new RemoveProduct(_context);
            }
        }

        private IGetDetailProductForSite _getDetailProductForSite;
        public IGetDetailProductForSite getDetailProductForSite
        {
            get
            {
                return _getDetailProductForSite = _getDetailProductForSite ?? new GetDetailProductForSite(_context);
            }
        }
    }
}
