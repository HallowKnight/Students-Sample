using System.Collections.Generic;
using MediatR;

namespace Students.Application.Lessons.Queries.GetAllLessons
{
    public class GetAllLessonsQuery : IRequest<List<GetAllLessonsDto>>
    {
    }
}