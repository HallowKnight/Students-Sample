using MediatR;
using Students.Application.Common.CommitTag;

namespace Students.Application.Roles.Commands.CreateRole;

public class CreateRoleCommand : IRequest<int>, ICommittable
{
    public string RoleTitle { get; set; }
    public int TransactionCount { get; set; }
}