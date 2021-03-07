using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Students.Domain.AggregatesModel.UserAggregate;
using Students.Domain.Common;

namespace Students.Application.Users.Commands.RemoveUserLesson
{
    public class RemoveStudentLessonCommandHandler : IRequestHandler<RemoveUserLessonCommand, int>
    {
        private readonly IUserCommands _userCommands;

        public RemoveStudentLessonCommandHandler(IUserCommands userCommands)
        {
            _userCommands = userCommands;
        }

        public async Task<int> Handle(RemoveUserLessonCommand request, CancellationToken cancellationToken)
        {
            await _userCommands.RemoveLessonFromUserAsync(request.UserId, request.LessonId);

            request.transctionCount += 1;

            return request.transctionCount;
        }
    }
}