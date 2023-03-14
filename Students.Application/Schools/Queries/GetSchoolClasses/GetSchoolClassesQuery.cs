using System.Collections.Generic;
using MediatR;

namespace Students.Application.Schools.Queries.GetSchoolClasses;

public class GetSchoolClassesQuery : IRequest<List<GetSchoolClassesDto>>
{
    public int SchoolId { get; set; }
}