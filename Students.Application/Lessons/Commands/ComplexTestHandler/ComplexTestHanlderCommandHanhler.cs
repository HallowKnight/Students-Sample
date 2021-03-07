using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Students.Domain.AggregatesModel.LessonAggregate;
using Students.Domain.AggregatesModel.UserAggregate;
using Students.Domain.Common;

namespace Students.Application.Lessons.Commands.ComplexTestHandler
{
    public class ComplexTestHandlerCommandHandler : IRequestHandler<ComplexTestHandlerCommand, int>
    {
        
        private readonly ILessonCommands _lessonCommands;
        private readonly IUserCommands _userCommands;
       

        public ComplexTestHandlerCommandHandler(ILessonCommands lessonCommands,
            IUserCommands studentCommands)
        {
            _lessonCommands = lessonCommands;
            _userCommands = studentCommands;
            
        }


        public async Task<int> Handle(ComplexTestHandlerCommand request, CancellationToken cancellationToken)
        {
            await _lessonCommands.AddLessonAsync(request.LessonName);
            request.transctionCount += 1;
            await _userCommands.AddLessonToUserAsync(request.UserId, request.LessonId);
            request.transctionCount += 1;
            await _userCommands.AddUserAsync(request.UserName);
            request.transctionCount += 1;
            await _userCommands.DeleteUserAsync(request.UserId);
            request.transctionCount += 1;
            
            return request.transctionCount;
        }
    }
}