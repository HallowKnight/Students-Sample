using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Students.Domain.AggregatesModel.SchoolAggregate;

namespace Students.Application.Schools.Queries.GetClass
{
    public class GetClassQueryHandler : IRequestHandler<GetClassQuery, GetClassDto>
    {
        private readonly ISchoolQueries _schoolQueries;

        public GetClassQueryHandler(ISchoolQueries schoolQueries)
        {
            _schoolQueries = schoolQueries;
        }

        public async Task<GetClassDto> Handle(GetClassQuery request, CancellationToken cancellationToken)
        {
            var currentClass =await _schoolQueries.GetClassByIdAsync(request.ClassId);

            return new GetClassDto()
            {
                ClassId = currentClass.Id,
                ClassTitle = currentClass.ClassTitle
            };
        }
    }
}