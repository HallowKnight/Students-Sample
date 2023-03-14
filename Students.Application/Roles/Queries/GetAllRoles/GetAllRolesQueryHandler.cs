using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Students.Domain.AggregatesModel.RoleAggregate;

namespace Students.Application.Roles.Queries.GetAllRoles;

public class GetAllRolesQueryHandler : IRequestHandler<GetAllRolesQuery, List<GetAllRolesDto>>
{
    private readonly IRoleQueries _roleQueries;

    public GetAllRolesQueryHandler(IRoleQueries roleQueries)
    {
        _roleQueries = roleQueries;
    }

    public async Task<List<GetAllRolesDto>> Handle(GetAllRolesQuery request, CancellationToken cancellationToken)
    {
        var roles = await _roleQueries.GetAllRolesAsync();
        var rolesDto = new List<GetAllRolesDto>();

        foreach (var role in roles)
            rolesDto.Add(new GetAllRolesDto
            {
                RoleId = role.Id,
                RoleTitle = role.RoleTitle
            });

        return rolesDto;
    }
}