namespace Shop.Application.Services.HomePage.Query.GetSliderForAdmin
{
    public class ResultGetSliderForAdmin
    {
        public List<GetSliderForAdminDto> Sliders { get; set; }
        public int Page { get; set; }
        public int RowsCount { get; set; }
        public int PageSize { get; set; }
    }
}
