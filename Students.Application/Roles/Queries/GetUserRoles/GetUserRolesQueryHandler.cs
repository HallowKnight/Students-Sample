using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Students.Domain.AggregatesModel.RoleAggregate;

namespace Students.Application.Roles.Queries.GetUserRoles
{
    public class GetUserRolesQueryHandler : IRequestHandler<GetUserRolesQuery,List<GetUserRolesDto>>
    {
        private readonly IRoleQueries _roleQueries;

        public GetUserRolesQueryHandler(IRoleQueries roleQueries)
        {
            _roleQueries = roleQueries;
        }
        
        public async Task<List<GetUserRolesDto>> Handle(GetUserRolesQuery request, CancellationToken cancellationToken)
        {
            List<Role> userRoles = await _roleQueries.GetUserRolesAsync(request.UserId);

            List<GetUserRolesDto> userRolesDtos = new List<GetUserRolesDto>();

            foreach (Role role in userRoles)
            {
                userRolesDtos.Add(new GetUserRolesDto()
                {
                    RoleId = role._Id,
                    RoleTitle = role.RoleTitle
                });
            }

            return userRolesDtos;
        }
    }
}