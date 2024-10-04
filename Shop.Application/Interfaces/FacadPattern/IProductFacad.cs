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

namespace Shop.Application.Interfaces.FacadPattern
{
    public interface IProductFacad
    {
        // command
        AddNewCategory NewCategoryService { get; }
        AddNewProduct addNewProductService { get; }
        RemoveCategory RemoveCategory { get; }
        RemoveProduct RemoveProduct { get;  }

        // query
        IGetCtegory getCtegory { get; }
        IGetProductForAdminService getProductForAdmin { get; }
        IGetDetailProductAdminService getDetailProductAdmin { get; }
        IGetAllCategories getAllCategories { get; }
        IGetProductForSiteService getProductForSiteService { get; }
        IGetDetailProductForSite getDetailProductForSite { get; }

    }
}
