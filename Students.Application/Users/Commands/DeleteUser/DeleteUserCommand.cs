using MediatR;
using Students.Application.Common.CommitTag;

namespace Students.Application.Users.Commands.DeleteUser
{
    public class DeleteUserCommand : IRequest<int> ,ICommitable
    {
        public int UserId { get; set; }
        public int transctionCount { get; set; }
    }
}