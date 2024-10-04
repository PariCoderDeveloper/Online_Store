using Shop.Ccommon.Dto;
using Shop.Domain.Entities.Product;
using Shop.Application.Interfaces.Context;
using Microsoft.VisualStudio.TestPlatform.PlatformAbstractions.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace Shop.Application.Services.Product.Command.AddNewProduct
{
    public partial class AddNewProduct : IAddNewProduct
    {
        private readonly IDataBaseContext _context;
        private readonly IHostingEnvironment _ev;
        public AddNewProduct(IDataBaseContext context,IHostingEnvironment ev)
        {
            _context = context;
            _ev = ev;
        }
        public async Task<ResultDto> ExecuteAsync(AddProductDto request)
        {
            if (request == null || string.IsNullOrEmpty(request.Name))
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "اطلاعات محصول صحیح نمی‌باشد"
                };
            }
            try
            {
                var category = _context.Category.Find(request.CategoryId);
                if (category == null)
                {
                    return new ResultDto
                    {
                        IsSuccess = false,
                        Message = "دسته بندی یافت نشد"
                    };
                }
                var Product = new Products
                {
                    Name = request.Name,
                    Brand = request.Brand,
                    Description = request.Description,
                    Price = request.Price,
                    Inventory = request.Inventory,
                    Category = category,
                    Displayed = request.Displayed,
                };
                _context.Products.Add(Product);

                // Add Images
                List<ProductImage> productImages = new List<ProductImage>();
                foreach (var item in request.Image)
                {
                    var uploadedResult = UploadFile(item);
                    productImages.Add(new ProductImage
                    {
                        Products = Product,
                        Src = uploadedResult.FileNameAddress
                    });
                }
                _context.ProductImage.AddRange(productImages);

                // Add Features
                List<ProductFeature> productFeatures = new List<ProductFeature>();
                foreach (var item in request.Features)
                {
                    productFeatures.Add(new ProductFeature
                    {
                        Products = Product,
                        DisplayName = item.DisplayName,
                        Value = item.Value
                    });
                }
                _context.ProductFeature.AddRange(productFeatures);

                await _context.SaveChangesAsync();
                return new ResultDto
                {
                    IsSuccess = true,
                    Message = "محصول موردنظر، با موفقیت به محصولات اضافه شد"
                };
            }
            catch (Exception e)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = e.Message
                };
            }
           
        }

        private UploadDto UploadFile(IFormFile file)
        {

            try
            {
                if (file != null || file.Length != 0)
                {
                    string folder = $@"Images\ProductImages\";
                    var uploadRootFolder = Path.Combine(_ev.WebRootPath, folder);
                    if (!Directory.Exists(uploadRootFolder))
                    {
                        Directory.CreateDirectory(uploadRootFolder);
                    }

                    string filename = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    var filePath = Path.Combine(uploadRootFolder, filename);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                    return new UploadDto
                    {
                        FileNameAddress = folder + filename,
                        Status = true
                    };
                } else {

                    return new UploadDto
                    {
                        FileNameAddress = "",
                        Status = false,
                    };
                }
            }
            catch 
            {
                return new UploadDto
                {
                    FileNameAddress = "",
                    Status = false
                };
            }

        }
    }

}
