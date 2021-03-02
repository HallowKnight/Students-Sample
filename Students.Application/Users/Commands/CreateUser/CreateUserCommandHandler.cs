using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Students.Domain.AggregatesModel.UserAggregate;
//using Students.Domain.Events;

namespace Students.Application.Users.Commands.CreateUser
{
    public class CreateStudentCommandHandler : IRequestHandler<CreateUserCommand,int>
    {

        private readonly IUserCommands _userCommands;

        public CreateStudentCommandHandler(IUserCommands userCommands)
        {
            _userCommands = userCommands;
            
        }
        
        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {

            User user = new User()
            {
                UserName = request.UserName
            };
            await _userCommands.AddUserAsync(user);
            
           // user.DomainEvents.Add(new UsersChangedEvent(user));
            
            request.transctionCount += 1;
            
            return request.transctionCount;
        }
    }
}