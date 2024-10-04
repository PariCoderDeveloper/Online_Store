namespace Shop.Application.Services.Users.Commands.LoginUser
{
    public class LoginUserDto
    {
        public long UserId { get; set; }
        public string Fullname { get; set; }
        public string Roles { get; set; }
    }
}
