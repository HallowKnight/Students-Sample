using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Students.Domain.AggregatesModel.LessonAggregate;
using Students.Domain.Common;

namespace Students.Application.Lessons.Commands.CreateLesson
{
    public class CreateLessonCommandHandler : IRequestHandler<CreateLessonCommand,int>
    {

        private readonly ILessonCommands _lessonCommands;
        private readonly IUnitOfWork _unitOfWork;
        
        public CreateLessonCommandHandler(ILessonCommands lessonCommands,IUnitOfWork unitOfWork)
        {
            _lessonCommands = lessonCommands;
            _unitOfWork = unitOfWork;
        }


        public async Task<int> Handle(CreateLessonCommand request, CancellationToken cancellationToken)
        {
         
            await _lessonCommands.AddLessonAsync(request.LessonTitle);
            request.transctionCount += 1;
            return request.transctionCount;
        }
    }
}