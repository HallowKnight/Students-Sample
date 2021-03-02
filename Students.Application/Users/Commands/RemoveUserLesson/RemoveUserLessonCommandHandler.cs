using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Students.Domain.AggregatesModel.UserAggregate;
using Students.Domain.Common;

namespace Students.Application.Users.Commands.RemoveUserLesson
{
    public class RemoveStudentLessonCommandHandler : IRequestHandler<RemoveUserLessonCommand,int>
    {
        
        private readonly IUserCommands _userCommands;
        private readonly IUnitOfWork _unitOfWork;

        public RemoveStudentLessonCommandHandler(IUserCommands userCommands,IUnitOfWork unitOfWork)
        {
            _userCommands = userCommands;
            _unitOfWork = unitOfWork;
        } 

        public async Task<int> Handle(RemoveUserLessonCommand request, CancellationToken cancellationToken)
        {
            _userCommands.RemoveLessonFromUser(request.UserId, request.LessonId);

            request.transctionCount += 1;
            
            return request.transctionCount;
        }
    }
}