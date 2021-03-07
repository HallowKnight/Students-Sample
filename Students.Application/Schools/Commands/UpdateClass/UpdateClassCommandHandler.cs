using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Students.Domain.AggregatesModel.SchoolAggregate;

namespace Students.Application.Schools.Commands.UpdateClass
{
    public class UpdateClassCommandHandler : IRequestHandler<UpdateClassCommand,int>
    {

        private readonly ISchoolCommands _schoolCommands;

        public UpdateClassCommandHandler(ISchoolCommands schoolCommands)
        {
            _schoolCommands = schoolCommands;
        }
        
        public async Task<int> Handle(UpdateClassCommand request, CancellationToken cancellationToken)
        {
            await _schoolCommands.UpdateClassAsync(request.ClassId,request.ClassTitle);
            request.transctionCount++;

            return request.transctionCount;
        }
    }
}