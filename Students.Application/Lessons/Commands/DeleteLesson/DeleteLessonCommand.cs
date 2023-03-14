using MediatR;
using Students.Application.Common.CommitTag;

namespace Students.Application.Lessons.Commands.DeleteLesson;

public class DeleteLessonCommand : IRequest<int>, ICommittable
{
    public int LessonId { get; set; }
    public int TransactionCount { get; set; }
}