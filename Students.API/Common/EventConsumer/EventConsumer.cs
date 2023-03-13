using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using Students.Application.Users.Queries.GetAllUsers;
using Students.Domain.Contracts;
using Students.Presentation.Common.Hubs;

namespace Students.Presentation.Common.EventConsumer
{
    public class EventConsumer : IConsumer<UsersChanged>
    {
        private readonly IHubContext<UsersListHub> _hub;
        private readonly IMediator _mediator;

        public EventConsumer(IHubContext<UsersListHub> hub, IMediator mediator)
        {
            _hub = hub;
            _mediator = mediator;
        }

        public async Task Consume(ConsumeContext<UsersChanged> context)
        {
            List<GetAllUsersDto> res = await _mediator.Send(new GetAllUsersQuery());
            await _hub.Clients.All.SendAsync("GetNewUsersList", res);
        }
    }
}