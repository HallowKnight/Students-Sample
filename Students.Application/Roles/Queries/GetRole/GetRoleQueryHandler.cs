using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Students.Domain.AggregatesModel.RoleAggregate;

namespace Students.Application.Roles.Queries.GetRole
{
    public class GetRoleQueryHandler : IRequestHandler<GetRoleQuery,GetRoleDto>
    {

        private readonly IRoleQueries _roleQueries;

        public GetRoleQueryHandler(IRoleQueries roleQueries)
        {
            _roleQueries = roleQueries;
        }
        
        public async Task<GetRoleDto> Handle(GetRoleQuery request, CancellationToken cancellationToken)
        {
            Role role =await _roleQueries.GetRoleByIdAsync(request.RoleId);
            GetRoleDto roleDto = new GetRoleDto()
            {
                RoleId = role._Id,
                RoleTitlle = role.RoleTitle
            };

            return roleDto;
        }
    }
}