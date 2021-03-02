using MediatR;
using Students.Application.Common.CommitTag;

namespace Students.Application.Roles.Commands.DeleteRole
{
    public class DeleteRoleCommand : IRequest<int>,ICommitable
    {
        public int transctionCount { get; set; }
        public int RoleId { get; set; }
    }
}