using Microsoft.AspNetCore.Http;

namespace Shop.Application.Services.HomePage.Cammand.AddNewSliderService
{
    public class AddNewSliderDto
    {
        public long? Id { get; set; }
        public IFormFile Image { get; set; }
        public string Link { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Text { get; set; }
        public bool Display  { get; set; }
    }


}
