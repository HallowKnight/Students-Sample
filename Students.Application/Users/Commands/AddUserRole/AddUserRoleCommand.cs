using MediatR;
using Students.Application.Common.CommitTag;

namespace Students.Application.Users.Commands.AddUserRole
{
    public class AddUserRoleCommand : IRequest<int>,ICommitable
    {
        public int UserId { get; set; }

        public int RoleId { get; set; }
        public int transctionCount { get; set; }
    }
}