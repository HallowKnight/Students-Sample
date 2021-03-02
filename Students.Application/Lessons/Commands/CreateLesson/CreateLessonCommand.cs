using MediatR;
using Students.Application.Common.CommitTag;

namespace Students.Application.Lessons.Commands.CreateLesson
{
    public class CreateLessonCommand : IRequest<int>,ICommitable
    {
        public string LessonTitle { get; set; }
        public int transctionCount { get; set; }
    }
}