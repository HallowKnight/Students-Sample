using MediatR;

namespace Students.Application.Users.Queries.GetUser;

public class GetUserQuery : IRequest<GetUserDto>
{
    public int UserId { get; set; }
}