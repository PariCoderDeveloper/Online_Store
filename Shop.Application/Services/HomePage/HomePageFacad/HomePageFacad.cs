using Microsoft.AspNetCore.Hosting;
using Shop.Application.Interfaces.Context;
using Shop.Application.Interfaces.FacadPattern;
using Shop.Application.Services.HomePage.Cammand.AddNewSliderService;
using Shop.Application.Services.HomePage.Query.GetSliderForAdmin;
using Shop.Application.Services.HomePage.Query.GetSliders;
using Shop.Application.Services.HomePage.Query.GetSliderWithId;
using Shop.Application.Services.Product.Command.AddNewProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Services.HomePage.HomePageFacad
{
    public class HomePageFacad : IHomePageFacad
    {
        private readonly IDataBaseContext _context;
        private readonly IHostingEnvironment _environment;
        public HomePageFacad(IDataBaseContext context, IHostingEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        private IGetSliders _getSliders;
        public IGetSliders getSliders
        {
            get
            {
                return _getSliders = _getSliders ?? new GetSliders(_context);
            }
        }

        private AddNewSliderService _addNewSliderService;
        public AddNewSliderService addNewSliderService
        {
            get
            {
                return _addNewSliderService = _addNewSliderService ?? new AddNewSliderService(_context, _environment);
            }
        }

        private IGetSliderForAdmin _getSliderForAdmin;
        public IGetSliderForAdmin getSliderForAdmin
        {
            get
            {
                return _getSliderForAdmin = _getSliderForAdmin ?? new GetSliderForAdminService(_context);
            }
        }

        private IGetSliderWithId _getSliderWithId;
        public IGetSliderWithId getSliderWithId
        {
            get
            {
                return _getSliderWithId = _getSliderWithId ?? new GetSliderWithId(_context);
            }
        }
    }
}
