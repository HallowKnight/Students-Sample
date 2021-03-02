using MediatR;
using Students.Application.Common.CommitTag;

namespace Students.Application.Roles.Commands.UpdateRole
{
    public class UpdateRoleCommand : IRequest<int>,ICommitable
    {
        public int transctionCount { get; set; }

        public int RoleId { get; set; }

        public string NewTitle { get; set; }
    }
}