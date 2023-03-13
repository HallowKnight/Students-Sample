using MediatR;
using Students.Application.Common.CommitTag;

namespace Students.Application.Roles.Commands.CreateRole
{
    public class CreateRoleCommand : IRequest<int>, ICommitable
    {
        public string RoleTitle { get; set; }
        public int TransactionCount { get; set; }
    }
}