using MediatR;

namespace Students.Application.Roles.Queries.GetRole
{
    public class GetRoleQuery : IRequest<GetRoleDto>
    {
        public int RoleId { get; set; }
    }
}