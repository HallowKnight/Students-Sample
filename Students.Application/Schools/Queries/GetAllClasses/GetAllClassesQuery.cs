using System.Collections.Generic;
using MediatR;

namespace Students.Application.Schools.Queries.GetAllClasses;

public class GetAllClassesQuery : IRequest<List<GetAllClassesDto>>
{
}