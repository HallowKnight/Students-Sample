using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Students.Domain.AggregatesModel.RoleAggregate;

namespace Students.Application.Roles.Commands.DeleteRole
{
    public class DeleteRoleCommandHandler : IRequestHandler<DeleteRoleCommand,int>
    {

        private readonly IRoleCommands _roleCommands;

        public DeleteRoleCommandHandler(IRoleCommands roleCommands)
        {
            _roleCommands = roleCommands;
        }
        
        public async Task<int> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
        {
            await _roleCommands.RemoveRoleAsync(request.RoleId);
            request.transctionCount++;
            return request.transctionCount;
        }
    }
}