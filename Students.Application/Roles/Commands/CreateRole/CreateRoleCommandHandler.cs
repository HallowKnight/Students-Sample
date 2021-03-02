using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Students.Domain.AggregatesModel.RoleAggregate;

namespace Students.Application.Roles.Commands.CreateRole
{
    public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand,int>
    {
        private readonly IRoleCommands _roleCommands;

        public CreateRoleCommandHandler(IRoleCommands roleCommands)
        {
            _roleCommands = roleCommands;
        }
        
        public async Task<int> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            await _roleCommands.AddRoleAsync(request.RoleTitle);
            request.transctionCount++;
            return request.transctionCount;
        }
    }
}