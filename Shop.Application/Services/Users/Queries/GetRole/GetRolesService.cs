using Shop.Application.Interfaces.Context;
using Shop.Ccommon.Dto;

namespace Shop.Application.Services.Users.Queries.GetRole
{
    public class GetRolesService : IGetRolesService
    {
        private readonly IDataBaseContext _context;
        public GetRolesService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto<List<RoleDto>> Execute()
        {
            try
            {
                var roles = _context.Roles.Select(p => new RoleDto
                {
                    Id = p.Id,
                    Name = p.Name,
                }).ToList();

                return new ResultDto<List<RoleDto>>
                {
                    Data = roles,
                    IsSuccess = true,
                    Message = "نقش ها با موفقیت استخراج شدند."
                };
            }
            catch (Exception e)
            {
                return new ResultDto<List<RoleDto>>
                {
                    IsSuccess = false,
                    Message = e.Message
                };

            }

        }
    }


}
