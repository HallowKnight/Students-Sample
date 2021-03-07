using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Students.Domain.AggregatesModel.SchoolAggregate;

namespace Students.Application.Schools.Commands.DeleteClass
{
    public class DeleteClassCommandHandler :IRequestHandler<DeteleClassCommand,int>
    {
        private readonly ISchoolCommands _schoolCommands;

        public DeleteClassCommandHandler(ISchoolCommands schoolCommands)
        {
            _schoolCommands = schoolCommands;
        }
        
        public async Task<int> Handle(DeteleClassCommand request, CancellationToken cancellationToken)
        {
            await _schoolCommands.DeleteClassAsync(request.ClassId);
            request.transctionCount++;

            return request.transctionCount;
        }
    }
}