using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Students.Domain.AggregatesModel.SchoolAggregate;

namespace Students.Application.Schools.Queries.GetAllClasses
{
    public class GetAllClassesQueryHandler : IRequestHandler<GetAllClassesQuery,List<GetAllClassesDto>>
    {

        private readonly ISchoolQueries _schoolQueries;

        public GetAllClassesQueryHandler(ISchoolQueries schoolQueries)
        {
            _schoolQueries = schoolQueries;
        }
        
        public async Task<List<GetAllClassesDto>> Handle(GetAllClassesQuery request, CancellationToken cancellationToken)
        {
            var classes = await _schoolQueries.GetAllClassesAsync();

            List<GetAllClassesDto> classesDtos = new List<GetAllClassesDto>();

            foreach (Class currentClass in classes)
            {
                classesDtos.Add(new GetAllClassesDto()
                {
                    ClassId = currentClass.Id,
                    ClassTitle = currentClass.ClassTitle
                });
            }

            return classesDtos;
        }
    }
}