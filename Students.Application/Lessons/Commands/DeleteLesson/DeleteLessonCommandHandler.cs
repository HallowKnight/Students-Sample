using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Students.Domain.AggregatesModel.LessonAggregate;

namespace Students.Application.Lessons.Commands.DeleteLesson
{
    public class DeleteLessonCommandHandler : IRequestHandler<DeleteLessonCommand, int>
    {
        private readonly ILessonCommands _lessonCommands;


        public DeleteLessonCommandHandler(ILessonCommands lessonCommands)
        {
            _lessonCommands = lessonCommands;
        }

        public async Task<int> Handle(DeleteLessonCommand request, CancellationToken cancellationToken)
        {
            await _lessonCommands.DeleteLessonAsync(request.LessonId);
            request.TransactionCount += 1;
            return request.TransactionCount;
        }
    }
}