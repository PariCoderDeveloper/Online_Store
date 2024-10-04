namespace Shop.Application.Services.Commen.Query.GetMenuService
{
    public class MenuServiceDto
    {
        public long CatId { get; set; }
        public string Name { get; set; }
        public List<MenuServiceDto> Child { get; set; }
    }
}
