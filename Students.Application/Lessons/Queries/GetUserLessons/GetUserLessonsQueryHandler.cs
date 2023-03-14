using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Students.Domain.AggregatesModel.LessonAggregate;
using Students.Domain.AggregatesModel.UserAggregate;

namespace Students.Application.Lessons.Queries.GetUserLessons;

public class GetUserLessonsQueryHandler : IRequestHandler<GetUserLessonsQuery, GetUserLessonsDto>
{
    private readonly ILessonQueries _lessonQueries;
    private readonly IUserQueries _studentQueries;

    public GetUserLessonsQueryHandler(ILessonQueries lessonQueries, IUserQueries studentQueries)
    {
        _lessonQueries = lessonQueries;
        _studentQueries = studentQueries;
    }

    public async Task<GetUserLessonsDto> Handle(GetUserLessonsQuery request, CancellationToken cancellationToken)
    {
        var user = await _studentQueries.GetUserByIdAsync(request.UserId);

        var lessonsDto = new GetUserLessonsDto
        {
            UserId = user.Id,
            UserName = user.UserName,
            UserLessons = await _lessonQueries.GetUserLessonsAsync(request.UserId)
        };
        return lessonsDto;
    }
}