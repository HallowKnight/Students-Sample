using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Students.Domain.AggregatesModel.LessonAggregate;

namespace Students.Application.Lessons.Queries.GetAllLessons
{
    public class GetALlLessonsQueryHandler : IRequestHandler<GetAllLessonsQuery,List<GetAllLessonsDto>>
    {
        private readonly ILessonQueries _lessonQueries;

        public GetALlLessonsQueryHandler(ILessonQueries lessonQueries)
        {
            _lessonQueries = lessonQueries;
        }
        
        public async Task<List<GetAllLessonsDto>> Handle(GetAllLessonsQuery request, CancellationToken cancellationToken)
        {

            List<Lesson> lessons =await _lessonQueries.GetAllLessonsAsync();
            List<GetAllLessonsDto> lessonsList = new List<GetAllLessonsDto>();
            
            
            foreach (Lesson l in lessons)
            { 
                lessonsList.Add(new GetAllLessonsDto()
                {
                    LessonId = l.Id,
                    LessonTitle = l.LessonTitle
                });
            }

            return lessonsList;
        }
    }
}