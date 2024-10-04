using Microsoft.EntityFrameworkCore;
using Shop.Application.Interfaces.Context;
using Shop.Ccommon;

namespace Shop.Application.Services.Users.Queries.GetUsers
{
    public class GetUserService : IGetUserService
    {
        //Constructor Injection
        private readonly IDataBaseContext _context;
        public GetUserService(IDataBaseContext context)
        {
            _context = context;
        }

        public async Task<ResultGetUserDto> ExecuteAsync(string SearchKey = "",
            int Page = 1, int PageSize = 10)
        {
            var users = _context.Users.AsQueryable();
            if (!string.IsNullOrWhiteSpace(SearchKey))
            {
                users = users.Where(p => p.Fullname.Contains(SearchKey) || p.Email.Contains(SearchKey));
            }
            int rowsCount = 0;
            var user = users.ToPaged(Page, PageSize, out rowsCount).Select(p => new GetUsersDto
            {
                Email = p.Email,
                Fullname = p.Fullname,
                Id = p.Id,
                IsActive = p.IsActive,
            }).ToList();
            return new ResultGetUserDto
            {
                Users = user,
                PageSize = PageSize,
                RowCount = rowsCount,
                CurrentPage = Page
            };
        }


    }
}
