using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Students.Domain.AggregatesModel.UserAggregate;
using Students.Domain.Events;
//using Students.Domain.Events;

namespace Students.Application.Users.Commands.CreateUser
{
    public class CreateStudentCommandHandler : IRequestHandler<CreateUserCommand,int>
    {

        private readonly IUserCommands _userCommands;
        private readonly IMediator _mediator;

        public CreateStudentCommandHandler(IUserCommands userCommands, IMediator mediator)
        {
            _userCommands = userCommands;
            _mediator = mediator;
        }
        
        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {

            User user = new User()
            {
                UserName = request.UserName
            };
            await _userCommands.AddUserAsync(user);
            
            user.DomainEvents.Add(new UsersChangedEvent(user));
            
            await _mediator.Publish(new UsersChangedEvent(user));
           
            request.transctionCount += 1;
            
            return request.transctionCount;
        }
    }
}