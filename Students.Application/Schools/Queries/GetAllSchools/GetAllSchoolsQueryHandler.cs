using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Students.Domain.AggregatesModel.SchoolAggregate;

namespace Students.Application.Schools.Queries.GetAllSchools;

public class GetAllSchoolsQueryHandler : IRequestHandler<GetAllSchoolsQuery, List<GetAllSchoolsDto>>
{
    private readonly ISchoolQueries _schoolQueries;

    public GetAllSchoolsQueryHandler(ISchoolQueries schoolQueries)
    {
        _schoolQueries = schoolQueries;
    }

    public async Task<List<GetAllSchoolsDto>> Handle(GetAllSchoolsQuery request,
        CancellationToken cancellationToken)
    {
        var schools = await _schoolQueries.GetAllSchoolsAsync();
        var schoolsDtos = new List<GetAllSchoolsDto>();

        foreach (var school in schools)
            schoolsDtos.Add(new GetAllSchoolsDto
            {
                SchoolId = school.Id,
                SchoolTitle = school.SchoolTitle
            });

        return schoolsDtos;
    }
}