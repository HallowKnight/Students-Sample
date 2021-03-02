using MediatR;
using Students.Application.Common.CommitTag;

namespace Students.Application.Users.Commands.RemoveUserRole
{
    public class RemoveUserRoleCommand : IRequest<int>,ICommitable
    {
        public int transctionCount { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }
    }
}