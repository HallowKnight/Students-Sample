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
        private readonly ILessonQueries _lessonQueries;
        private readonly IUserCommands _userCommands;
        private readonly IUserQueries _userQueries;
        private readonly IUnitOfWork _unitOfWork;

        public ComplexTestHandlerCommandHandler(ILessonCommands lessonCommands, ILessonQueries lessonQueries,
            IUserCommands studentCommands, IUserQueries studentQueries, IUnitOfWork unitOfWork)
        {
            _lessonCommands = lessonCommands;
            _lessonQueries = lessonQueries;
            _userCommands = studentCommands;
            _userQueries = studentQueries;
            _unitOfWork = unitOfWork;
        }


        public async Task<int> Handle(ComplexTestHandlerCommand request, CancellationToken cancellationToken)
        {
            Lesson l = new Lesson() {LessonTitle = request.LessonName, Id = 545};


            await _lessonCommands.AddLessonAsync(l);
            request.transctionCount += 1;
            await _userCommands.AddLessonToUserAsync(request.UserId, l.Id);
            request.transctionCount += 1;
            await _userCommands.AddUserAsync(new User() {UserName = request.UserName});
            request.transctionCount += 1;
            _userCommands.DeleteUser(await _userQueries.GetUserByIdAsync(request.UserId));
            request.transctionCount += 1;
            
            return request.transctionCount;
        }
    }
}