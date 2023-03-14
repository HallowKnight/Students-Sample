using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Students.Domain.AggregatesModel.SchoolAggregate;

namespace Students.Application.Schools.Queries.GetAllClasses;

public class GetAllClassesQueryHandler : IRequestHandler<GetAllClassesQuery, List<GetAllClassesDto>>
{
    private readonly ISchoolQueries _schoolQueries;

    public GetAllClassesQueryHandler(ISchoolQueries schoolQueries)
    {
        _schoolQueries = schoolQueries;
    }

    public async Task<List<GetAllClassesDto>> Handle(GetAllClassesQuery request,
        CancellationToken cancellationToken)
    {
        var classes = await _schoolQueries.GetAllClassesAsync();

        var classesDtos = new List<GetAllClassesDto>();

        foreach (var currentClass in classes)
            classesDtos.Add(new GetAllClassesDto
            {
                ClassId = currentClass.Id,
                ClassTitle = currentClass.ClassTitle
            });

        return classesDtos;
    }
}