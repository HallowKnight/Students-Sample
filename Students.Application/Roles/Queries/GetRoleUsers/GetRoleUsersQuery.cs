using System.Collections.Generic;
using MediatR;

namespace Students.Application.Roles.Queries.GetRoleUsers;

public class GetRoleUsersQuery : IRequest<List<GetRoleUsersDto>>
{
    public int RoleId { get; set; }
}