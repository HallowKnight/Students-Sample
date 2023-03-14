using MediatR;

namespace Students.Application.Schools.Queries.GetSchool;

public class GetSchoolQuery : IRequest<GetSchoolDto>
{
    public int SchoolId { get; set; }
}