using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Students.Domain.AggregatesModel.SchoolAggregate;

namespace Students.Application.Schools.Commands.UpdateSchool
{
    public class UpdateSchoolCommandHandler : IRequestHandler<UpdateSchoolCommand,int>
    {

        private readonly ISchoolCommands _schoolCommands;

        public UpdateSchoolCommandHandler(ISchoolCommands schoolCommands)
        {
            _schoolCommands = schoolCommands;
        }

        public async Task<int> Handle(UpdateSchoolCommand request, CancellationToken cancellationToken)
        {
            _schoolCommands.UpdateSchool(request.SchoolId,request.SchoolTitle);
            request.transctionCount++;

            return request.transctionCount;
        }
    }
}