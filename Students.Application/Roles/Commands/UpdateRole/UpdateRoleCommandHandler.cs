using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Students.Domain.AggregatesModel.RoleAggregate;

namespace Students.Application.Roles.Commands.UpdateRole
{
    public class UpdateRoleCommandHandler : IRequestHandler<UpdateRoleCommand,int>
    {
        private readonly IRoleCommands _roleCommands;

        public UpdateRoleCommandHandler(IRoleCommands roleCommands)
        {
            _roleCommands = roleCommands;
        }
        
        public async Task<int> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
        {
            await _roleCommands.UpdateRoleAsync(request.RoleId,request.NewTitle);
            request.transctionCount++;
            return request.transctionCount;
        }
    }
}