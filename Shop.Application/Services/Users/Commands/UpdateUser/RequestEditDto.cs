namespace Shop.Application.Services.Users.Commands.UpdateUser
{
    public class RequestEditDto
    {
        public long UserId { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
    }

}
