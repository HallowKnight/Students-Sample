using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using Students.Application.Users.Queries.GetAllUsers;
using Students.Domain.Common;
using Students.Domain.Events.UsersChanged;
using Students.Presentation.Hubs;

namespace Students.Presentation.Common.Events.UserCreated
{
    public class UsersChangedEventHandler : INotificationHandler<UsersChangedEvent>
    {

        private readonly IHubContext<UsersListHub> _hub;
        private readonly IMediator _mediator;

        public UsersChangedEventHandler(IHubContext<UsersListHub> hub, IMediator mediator)
        {
            _hub = hub;
            _mediator = mediator;
        }

        public async Task Handle(UsersChangedEvent notification, CancellationToken cancellationToken)
        {
            var result =await _mediator.Send(new GetAllUsersQuery());

            await _hub.Clients.All.SendAsync("GetNewUsersList", result);
            
        }
    }
}