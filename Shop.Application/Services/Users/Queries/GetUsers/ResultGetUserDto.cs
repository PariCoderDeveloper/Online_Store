namespace Shop.Application.Services.Users.Queries.GetUsers
{
    public class ResultGetUserDto
    {
        public int RowCount { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public List<GetUsersDto> Users { get; set; }
    }
}
