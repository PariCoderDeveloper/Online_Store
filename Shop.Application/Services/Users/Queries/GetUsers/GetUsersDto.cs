namespace Shop.Application.Services.Users.Queries.GetUsers
{
    public class GetUsersDto
    {
        public long Id { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public string PasswordHash { get; set; }

    }
}
