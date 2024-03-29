﻿using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Students.Domain.AggregatesModel.SchoolAggregate;

namespace Students.Application.Schools.Queries.GetSchoolClasses
{
    public class GetSchoolClassesQueryHandler : IRequestHandler<GetSchoolClassesQuery, List<GetSchoolClassesDto>>
    {
        private readonly ISchoolQueries _schoolQueries;

        public GetSchoolClassesQueryHandler(ISchoolQueries schoolQueries)
        {
            _schoolQueries = schoolQueries;
        }

        public async Task<List<GetSchoolClassesDto>> Handle(GetSchoolClassesQuery request,
            CancellationToken cancellationToken)
        {
            List<Class> classes = await _schoolQueries.GetSchoolClassesAsync(request.SchoolId);

            List<GetSchoolClassesDto> classesDtos = new List<GetSchoolClassesDto>();

            foreach (Class currentClass in classes)
                classesDtos.Add(new GetSchoolClassesDto
                {
                    ClassId = currentClass.Id,
                    ClassTitle = currentClass.ClassTitle
                });

            return classesDtos;
        }
    }
}