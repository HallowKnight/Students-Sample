using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Students.Domain.AggregatesModel.UserAggregate;

namespace Students.Application.Users.Commands.AddUserRole
{
    public class AddUserRoleCommandHandler : IRequestHandler<AddUserRoleCommand, int>
    {
        private readonly IUserCommands _userCommands;

        public AddUserRoleCommandHandler(IUserCommands userCommands)
        {
            _userCommands = userCommands;
        }


        public async Task<int> Handle(AddUserRoleCommand request, CancellationToken cancellationToken)
        {
            await _userCommands.AddRoleToUserAsync(request.UserId, request.RoleId);
            request.TransactionCount++;
            return request.TransactionCount;
        }
    }
}