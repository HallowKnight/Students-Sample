using MediatR;
using Students.Application.Common.CommitTag;

namespace Students.Application.Lessons.Commands.ComplexTestHandler;

// Used to Trigger Specified Command Handler
public class ComplexTestHandlerCommand : IRequest<int>, ICommittable
{
    public string UserName { get; set; }

    public string LessonName { get; set; }

    public int UserId { get; set; }

    public int LessonId { get; set; }


    public int TransactionCount { get; set; }
}