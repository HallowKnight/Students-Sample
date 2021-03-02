using System.Net.NetworkInformation;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Students.Domain.AggregatesModel.LessonAggregate;
using Students.Domain.Common;

namespace Students.Application.Lessons.Commands.UpdateLesson
{
    public class UpdateLessonCommandHandler : IRequestHandler<UpdateLessonCommand,int>
    {
        private readonly ILessonCommands _lessonCommands;
        private readonly ILessonQueries _lessonQueries;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateLessonCommandHandler(ILessonCommands lessonCommands,ILessonQueries lessonQueries,IUnitOfWork unitOfWork)
        {
            _lessonCommands = lessonCommands;
            _lessonQueries = lessonQueries;
            _unitOfWork = unitOfWork;
        }
        
        
        public async Task<int> Handle(UpdateLessonCommand request, CancellationToken cancellationToken)
        {
            Lesson lesson = await _lessonQueries.GetLessonByIdAsync(request.LessonId);
            
            lesson.LessonTitle = request.NewTitle;
            _lessonCommands.UpdateLesson(lesson);
            request.transctionCount += 1;
            
            return request.transctionCount;
        }
    }
}