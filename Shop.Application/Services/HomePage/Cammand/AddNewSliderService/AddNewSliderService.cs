using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Shop.Application.Interfaces.Context;
using Shop.Ccommon.Dto;
using Shop.Domain.Entities.HomePage;
using System.Security.AccessControl;

namespace Shop.Application.Services.HomePage.Cammand.AddNewSliderService
{
    public class AddNewSliderService : IAddNewSliderService
    {
        private readonly IDataBaseContext _context;
        private readonly IHostingEnvironment _environment;
        public AddNewSliderService(IDataBaseContext context,
            IHostingEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }
        public async Task<ResultDto> ExecuteAsync(AddNewSliderDto request)
        {
            try
            {
                if (request == null)
                {
                    return new ResultDto
                    {
                        IsSuccess = false,
                        Message = "اطلاعاتی وارد نشده است"
                    };
                }
                var resultUpload = UploadFile(request.Image);
                if (!resultUpload.Status)
                {
                    return new ResultDto
                    {
                        IsSuccess = false,
                        Message = "فرایند آپلود تصویر با شکست مواجه شد"
                    };
                }

                var result =await _context.Sliders.FindAsync(request.Id);
                if (result != null)
                {
                    return new ResultDto
                    {
                        IsSuccess = true,
                        Message = ""
                    };
                }
                else
                {
                    Slider slider = new Slider
                    {
                        Src = resultUpload.FileNameAddres,
                        Link = request.Link,
                        Title = request.Title,
                        SubTitle = request.SubTitle,
                        Text = request.Text,
                        Display = request.Display
                    };
                    _context.Sliders.Add(slider);
                    await _context.SaveChangesAsync();
                    return new ResultDto
                    {
                        IsSuccess = true,
                        Message = "عکس با موفقیت به مجموعه عکس ها اضافه شد."
                    };
                }
            }
            catch (Exception ex)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }

        }
        private UploadDto UploadFile(IFormFile file)
        {
            try
            {
                if (file != null || file.Length != 0)
                {
                    string path = $@"Images\Sliders\";
                    var uploadRootFolder = Path.Combine(_environment.WebRootPath, path);
                    if (!Directory.Exists(uploadRootFolder))
                    {
                        Directory.CreateDirectory(uploadRootFolder);
                    }
                    string filename = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string filepath = Path.Combine(uploadRootFolder, filename);
                    using (var filestream = new FileStream(filepath, FileMode.Create))
                    {
                        file.CopyTo(filestream);    
                    }
                    return new UploadDto
                    {
                        FileNameAddres = path + filename,
                        Status = true
                    };
                }
                else
                {
                    return new UploadDto
                    {
                        FileNameAddres = "",
                        Status = false
                    };
                }
            }
            catch (Exception)
            {
                return new UploadDto
                {
                    FileNameAddres = "",
                    Status = false
                };
            }
        }

    }

}
