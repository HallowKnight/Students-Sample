using MediatR;

namespace Students.Application.Lessons.Queries.GetUserLessons;

public class GetUserLessonsQuery : IRequest<GetUserLessonsDto>
{
    public int UserId { get; set; }
}