using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Students.Domain.AggregatesModel.LessonAggregate;
using Students.Domain.Common;

namespace Students.Application.Lessons.Commands.DeleteLesson
{
    public class DeleteLessonCommandHandler : IRequestHandler<DeleteLessonCommand,int>
    {

        private readonly ILessonCommands _lessonCommands;
        private readonly ILessonQueries _lessonQueries;
        private readonly IUnitOfWork _unitOfWork;

     
        public DeleteLessonCommandHandler(ILessonCommands lessonCommands,ILessonQueries lessonQueries,IUnitOfWork unitOfWork)
        {
            _lessonCommands = lessonCommands;
            _lessonQueries = lessonQueries;
            _unitOfWork = unitOfWork;
        }
        
        public async Task<int> Handle(DeleteLessonCommand request, CancellationToken cancellationToken)
        {
            await _lessonCommands.DeleteLessonAsync(request.LessonId);
            request.transctionCount += 1;
            return request.transctionCount;
        }
    }
}