using MediatR;
using Students.Application.Common.CommitTag;

namespace Students.Application.Users.Commands.RemoveUserLesson;

public class RemoveUserLessonCommand : IRequest<int>, ICommittable
{
    public int UserId { get; set; }

    public int LessonId { get; set; }
    public int TransactionCount { get; set; }
}