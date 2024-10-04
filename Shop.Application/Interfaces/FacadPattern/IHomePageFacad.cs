using Shop.Application.Services.HomePage.Cammand.AddNewSliderService;
using Shop.Application.Services.HomePage.Query.GetSliderForAdmin;
using Shop.Application.Services.HomePage.Query.GetSliders;
using Shop.Application.Services.HomePage.Query.GetSliderWithId;
using Shop.Application.Services.Product.Command.AddNewCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Interfaces.FacadPattern
{
    public interface IHomePageFacad
    {
        // Query
        IGetSliders getSliders { get; }
        IGetSliderForAdmin getSliderForAdmin { get; }
        IGetSliderWithId getSliderWithId { get; }

        // Command
        AddNewSliderService addNewSliderService { get; }

    }
}
