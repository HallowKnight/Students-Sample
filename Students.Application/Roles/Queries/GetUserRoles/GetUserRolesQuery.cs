using System.Collections.Generic;
using MediatR;

namespace Students.Application.Roles.Queries.GetUserRoles;

public class GetUserRolesQuery : IRequest<List<GetUserRolesDto>>
{
    public int UserId { get; set; }
}