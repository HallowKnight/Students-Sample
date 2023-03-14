using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Students.Domain.AggregatesModel.LessonAggregate;

namespace Students.Application.Lessons.Commands.UpdateLesson;

public class UpdateLessonCommandHandler : IRequestHandler<UpdateLessonCommand, int>
{
    private readonly ILessonCommands _lessonCommands;

    public UpdateLessonCommandHandler(ILessonCommands lessonCommands)
    {
        _lessonCommands = lessonCommands;
    }


    public async Task<int> Handle(UpdateLessonCommand request, CancellationToken cancellationToken)
    {
        await _lessonCommands.UpdateLessonAsync(request.LessonId, request.NewTitle);
        request.TransactionCount += 1;

        return request.TransactionCount;
    }
}