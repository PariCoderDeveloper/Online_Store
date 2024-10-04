namespace Shop.Application.Services.Product.Queries.GetProductForAdmin
{
    public class ProductForAdminDto
    {
        //Pagination
        public int RowCount { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public List<ProductsForAdminList_Dto> Products { get; set; }
    }
}
