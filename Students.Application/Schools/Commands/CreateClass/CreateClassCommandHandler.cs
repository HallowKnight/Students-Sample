using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Students.Domain.AggregatesModel.SchoolAggregate;

namespace Students.Application.Schools.Commands.CreateClass
{
    public class CreateClassCommandHandler : IRequestHandler<CreateClassCommand,int>
    {

        private readonly ISchoolCommands _schoolCommands;

        public CreateClassCommandHandler(ISchoolCommands schoolCommands)
        {
            _schoolCommands = schoolCommands;
        }
        
        public async Task<int> Handle(CreateClassCommand request, CancellationToken cancellationToken)
        {
            await _schoolCommands.CreateClassAsync(request.ClassTitle, request.SchoolId);
            request.transctionCount++;
            return request.transctionCount;
        }
    }
}