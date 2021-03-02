using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Students.Domain.AggregatesModel.SchoolAggregate;

namespace Students.Application.Schools.Commands.DeleteSchool
{
    public class DeleteSchoolCommandHandler : IRequestHandler<DeleteSchoolCommand,int>
    {

        private readonly ISchoolCommands _schoolCommands;

        public DeleteSchoolCommandHandler(ISchoolCommands schoolCommands)
        {
            _schoolCommands = schoolCommands;
        }
        
        
        public async Task<int> Handle(DeleteSchoolCommand request, CancellationToken cancellationToken)
        {
            _schoolCommands.DeleteSchool(request.SchoolId);
            request.transctionCount++;

            return request.transctionCount;
        }
    }
}