using MediatR;
using Students.Application.Common.CommitTag;

namespace Students.Application.Roles.Commands.UpdateRole;

public class UpdateRoleCommand : IRequest<int>, ICommittable
{
    public int RoleId { get; set; }

    public string NewTitle { get; set; }
    public int TransactionCount { get; set; }
}