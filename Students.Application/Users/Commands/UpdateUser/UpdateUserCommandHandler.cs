using System.Threading;
using System.Threading.Tasks;
using MassTransit;
using MediatR;
using Students.Domain.AggregatesModel.UserAggregate;
using Students.Domain.Contracts;

namespace Students.Application.Users.Commands.UpdateUser
{
    public class UpdateStudentCommandHandler : IRequestHandler<UpdateUserCommand,int>
    {
        
        private readonly IUserCommands _userCommands;
        private readonly IPublishEndpoint _publishEndpoint;

        public UpdateStudentCommandHandler(IUserCommands userCommands, IPublishEndpoint publishEndpoint)
        {
            _userCommands = userCommands;
            _publishEndpoint = publishEndpoint;
        }
        public async Task<int> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {

            await _userCommands.UpdateUserAsync(request.UserNewName,request.UserId);
            await _publishEndpoint.Publish<UsersChanged>(request);
            
            request.transctionCount += 1;
            
            return request.transctionCount;
        }
    }
}