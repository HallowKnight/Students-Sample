using System.Collections.Generic;
using MediatR;

namespace Students.Application.Schools.Queries.GetAllSchools
{
    public class GetAllSchoolsQuery : IRequest<List<GetAllSchoolsDto>>
    { }
}