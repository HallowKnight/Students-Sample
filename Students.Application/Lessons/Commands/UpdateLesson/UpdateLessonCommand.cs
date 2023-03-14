using MediatR;
using Students.Application.Common.CommitTag;

namespace Students.Application.Lessons.Commands.UpdateLesson;

public class UpdateLessonCommand : IRequest<int>, ICommitable
{
    public int LessonId { get; set; }

    public string NewTitle { get; set; }
    public int TransactionCount { get; set; }
}