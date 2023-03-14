using MediatR;
using Students.Application.Common.CommitTag;

namespace Students.Application.Users.Commands.UpdateUser;

public class UpdateUserCommand : IRequest<int>, ICommittable
{
    public int UserId { get; set; }

    public string UserNewName { get; set; }
    public int TransactionCount { get; set; }
}