using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Students.Domain.AggregatesModel.LessonAggregate;
using Students.Domain.AggregatesModel.UserAggregate;
using Students.Domain.Common;

namespace Students.Application.Lessons.Queries.GetUserLessons
{
    public class GetUserLessonsQueryHandler : IRequestHandler<GetUserLessonsQuery, GetUserLessonsDto>
    {
        private readonly ILessonQueries _lessonQueries;
        private readonly IUserQueries _studentQueries;
        private readonly IUnitOfWork _unitOfWork;

        public GetUserLessonsQueryHandler(ILessonQueries lessonQueries,IUserQueries studentQueries,IUnitOfWork unitOfWork)
        {
            _lessonQueries = lessonQueries;
            _studentQueries = studentQueries;
            _unitOfWork = unitOfWork;
        }
        
        public async Task<GetUserLessonsDto> Handle(GetUserLessonsQuery request, CancellationToken cancellationToken)
        {

            User user = await _studentQueries.GetUserByIdAsync(request.UserId);

            GetUserLessonsDto lessonsDto = new GetUserLessonsDto()
            {
                UserId = user.Id,
                UserName = user.UserName,
                UserLessons = await _lessonQueries.GetUserLessonsAsync(request.UserId)
            };
            return lessonsDto;
        }
    }
}