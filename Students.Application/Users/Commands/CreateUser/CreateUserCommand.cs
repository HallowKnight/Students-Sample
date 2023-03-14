using MediatR;
using Students.Application.Common.CommitTag;

namespace Students.Application.Users.Commands.CreateUser;

public class CreateUserCommand : IRequest<int>, ICommittable
{
    public string UserName { get; set; }
    public int TransactionCount { get; set; }
}