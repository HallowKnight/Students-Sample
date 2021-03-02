using MediatR;
using Students.Application.Common.CommitTag;

namespace Students.Application.Users.Commands.UpdateUser
{
    public class UpdateUserCommand : IRequest<int>,ICommitable
    {
        public int UserId { get; set; }

        public string UserNewName { get; set; }
        public int transctionCount { get; set; }
    }
}