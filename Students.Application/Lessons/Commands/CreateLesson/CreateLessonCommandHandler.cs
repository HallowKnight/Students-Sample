using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Students.Domain.AggregatesModel.LessonAggregate;

namespace Students.Application.Lessons.Commands.CreateLesson;

public class CreateLessonCommandHandler : IRequestHandler<CreateLessonCommand, int>
{
    private readonly ILessonCommands _lessonCommands;

    public CreateLessonCommandHandler(ILessonCommands lessonCommands)
    {
        _lessonCommands = lessonCommands;
    }


    public async Task<int> Handle(CreateLessonCommand request, CancellationToken cancellationToken)
    {
        await _lessonCommands.AddLessonAsync(request.LessonTitle);
        request.TransactionCount += 1;
        return request.TransactionCount;
    }
}