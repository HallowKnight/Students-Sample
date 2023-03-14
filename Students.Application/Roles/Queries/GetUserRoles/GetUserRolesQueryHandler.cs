using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Students.Domain.AggregatesModel.RoleAggregate;

namespace Students.Application.Roles.Queries.GetUserRoles;

public class GetUserRolesQueryHandler : IRequestHandler<GetUserRolesQuery, List<GetUserRolesDto>>
{
    private readonly IRoleQueries _roleQueries;

    public GetUserRolesQueryHandler(IRoleQueries roleQueries)
    {
        _roleQueries = roleQueries;
    }

    public async Task<List<GetUserRolesDto>> Handle(GetUserRolesQuery request, CancellationToken cancellationToken)
    {
        var userRoles = await _roleQueries.GetUserRolesAsync(request.UserId);

        var userRolesDtos = new List<GetUserRolesDto>();

        foreach (var role in userRoles)
            userRolesDtos.Add(new GetUserRolesDto
            {
                RoleId = role.Id,
                RoleTitle = role.RoleTitle
            });

        return userRolesDtos;
    }
}