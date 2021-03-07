using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Students.Domain.AggregatesModel.RoleAggregate;

namespace Students.Application.Roles.Queries.GetAllRoles
{
    public class GetAllRolesQueryHandler : IRequestHandler<GetAllRolesQuery,List<GetAllRolesDto>>
    {
        private readonly IRoleQueries _roleQueries;

        public GetAllRolesQueryHandler(IRoleQueries roleQueries)
        {
            _roleQueries = roleQueries;
        }
        
        public async Task<List<GetAllRolesDto>> Handle(GetAllRolesQuery request, CancellationToken cancellationToken)
        {
            List<Role> roles = await _roleQueries.GetAllRolesAsync();
            List<GetAllRolesDto> rolesDto = new List<GetAllRolesDto>();

            foreach (Role role in roles)
            {
                rolesDto.Add(new GetAllRolesDto()
                {
                    RoleId = role._Id,
                    RoleTitle = role.RoleTitle
                });
            }

            return rolesDto;
        }
    }
}