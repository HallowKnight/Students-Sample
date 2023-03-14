using MediatR;
using Students.Application.Common.CommitTag;

namespace Students.Application.Users.Commands.RemoveUserRole;

public class RemoveUserRoleCommand : IRequest<int>, ICommittable
{
    public int UserId { get; set; }
    public int RoleId { get; set; }
    public int TransactionCount { get; set; }
}