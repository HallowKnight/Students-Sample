using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Students.Domain.AggregatesModel.SchoolAggregate;

namespace Students.Application.Schools.Queries.GetSchool
{
    public class GetSchoolQueryHandler : IRequestHandler<GetSchoolQuery,GetSchoolDto>
    {

        private readonly ISchoolQueries _schoolQueries;

        public GetSchoolQueryHandler(ISchoolQueries schoolQueries)
        {
            _schoolQueries = schoolQueries;
        }
        
        public async Task<GetSchoolDto> Handle(GetSchoolQuery request, CancellationToken cancellationToken)
        {
            School school = await _schoolQueries.GetSchoolByIdAsync(request.SchoolId);

            return new GetSchoolDto()
            {
                SchoolId = school.Id,
                SchoolTitle = school.SchoolTitle
            };
        }
    }
}