using MediatR;
using Students.Application.Common.CommitTag;

namespace Students.Application.Users.Commands.AddUserLesson
{
    public class AddUserLessonCommand : IRequest<int>, ICommitable
    {
        public int UserId { get; set; }

        public int LessonId { get; set; }
        public int TransactionCount { get; set; }
    }
}