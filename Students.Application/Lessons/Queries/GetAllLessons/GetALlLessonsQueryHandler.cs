using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Students.Domain.AggregatesModel.LessonAggregate;

namespace Students.Application.Lessons.Queries.GetAllLessons
{
    public class GetALlLessonsQueryHandler : IRequestHandler<GetAllLessonsQuery, List<GetAllLessonsDto>>
    {
        private readonly ILessonQueries _lessonQueries;

        public GetALlLessonsQueryHandler(ILessonQueries lessonQueries)
        {
            _lessonQueries = lessonQueries;
        }

        public async Task<List<GetAllLessonsDto>> Handle(GetAllLessonsQuery request,
            CancellationToken cancellationToken)
        {
            List<Lesson> lessons = await _lessonQueries.GetAllLessonsAsync();
            return lessons.Select(lesson => new GetAllLessonsDto
                { LessonId = lesson.Id, LessonTitle = lesson.LessonTitle }).ToList();
        }
    }
}