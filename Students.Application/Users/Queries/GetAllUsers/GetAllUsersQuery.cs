using System.Collections.Generic;
using MediatR;

namespace Students.Application.Users.Queries.GetAllUsers;

public class GetAllUsersQuery : IRequest<List<GetAllUsersDto>>
{
}