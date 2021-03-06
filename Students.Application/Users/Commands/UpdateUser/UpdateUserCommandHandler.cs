using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Students.Domain.AggregatesModel.UserAggregate;
using Students.Domain.Events;
using Students.Domain.Events.UsersChanged;

namespace Students.Application.Users.Commands.UpdateUser
{
    public class UpdateStudentCommandHandler : IRequestHandler<UpdateUserCommand,int>
    {
        
        private readonly IUserCommands _userCommands;
        private readonly IUserQueries _userQueries;
        private readonly IMediator _mediator;

        public UpdateStudentCommandHandler(IUserCommands userCommands, IUserQueries userQueries, IMediator mediator)
        {
            _userCommands = userCommands;
            _userQueries = userQueries;
            _mediator = mediator;
            
        }
        
        public async Task<int> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {

            _userCommands.UpdateUser(request.UserNewName,request.UserId);

            await _mediator.Publish(new UsersChangedEvent());


            request.transctionCount += 1;



            return request.transctionCount;
            
        }
    }
}