using MediatR;
using Students.Application.Common.CommitTag;

namespace Students.Application.Roles.Commands.CreateRole
{
    public class CreateRoleCommand : IRequest<int>,ICommitable
    {
        public int transctionCount { get; set; }
        public string RoleTitle { get; set; }
    }
}