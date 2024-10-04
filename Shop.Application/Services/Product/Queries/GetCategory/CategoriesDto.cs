namespace Shop.Application.Services.Product.Queries.GetCategory
{
    public class CategoriesListDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public bool HasChild { get; set; }
        public ParentCategoryDto Parent { get; set; }
    }

    public class CategoriesDto
    {
        public int RowCount { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public List<CategoriesListDto> categories { get; set; }
    }
}
