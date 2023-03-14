using MediatR;

namespace Students.Application.Schools.Queries.GetClass;

public class GetClassQuery : IRequest<GetClassDto>
{
    public int ClassId { get; set; }
}