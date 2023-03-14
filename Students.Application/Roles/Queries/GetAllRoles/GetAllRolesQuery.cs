using System.Collections.Generic;
using MediatR;

namespace Students.Application.Roles.Queries.GetAllRoles;

public class GetAllRolesQuery : IRequest<List<GetAllRolesDto>>
{
}