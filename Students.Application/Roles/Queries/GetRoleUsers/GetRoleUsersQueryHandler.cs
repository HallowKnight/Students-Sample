using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Students.Domain.AggregatesModel.RoleAggregate;

namespace Students.Application.Roles.Queries.GetRoleUsers;

public class GetRoleUsersQueryHandler : IRequestHandler<GetRoleUsersQuery, List<GetRoleUsersDto>>
{
    private readonly IRoleQueries _roleQueries;

    public GetRoleUsersQueryHandler(IRoleQueries roleQueries)
    {
        _roleQueries = roleQueries;
    }

    public async Task<List<GetRoleUsersDto>> Handle(GetRoleUsersQuery request, CancellationToken cancellationToken)
    {
        var roleUsers = await _roleQueries.GetRoleUsersAsync(request.RoleId);

        var roleUsersDto = new List<GetRoleUsersDto>();

        foreach (var user in roleUsers)
            roleUsersDto.Add(new GetRoleUsersDto
            {
                UserId = user.Id,
                UserName = user.UserName
            });

        return roleUsersDto;
    }
}