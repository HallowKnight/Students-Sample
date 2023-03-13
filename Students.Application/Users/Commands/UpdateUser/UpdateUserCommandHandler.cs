using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Students.Domain.AggregatesModel.UserAggregate;
using Students.Domain.Contracts;

namespace Students.Application.Users.Commands.UpdateUser
{
    public class UpdateStudentCommandHandler : IRequestHandler<UpdateUserCommand, int>
    {
        private readonly IPublishEndpoint _publishEndpoint;

        private readonly IUserCommands _userCommands;

        public UpdateStudentCommandHandler(IUserCommands userCommands, IPublishEndpoint publishEndpoint)
        {
            _userCommands = userCommands;
            _publishEndpoint = publishEndpoint;
        }

        public async Task<int> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            await _userCommands.UpdateUserAsync(request.UserNewName, request.UserId);
            await _publishEndpoint.Publish<UsersChanged>(request);

            request.TransactionCount += 1;

            return request.TransactionCount;
        }
    }
}