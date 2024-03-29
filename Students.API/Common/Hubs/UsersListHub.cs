﻿using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using Students.Application.Users.Queries.GetAllUsers;

namespace Students.Presentation.Common.Hubs
{
    public class UsersListHub : Hub
    {
        private readonly IMediator _mediator;

        public UsersListHub(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task UsersListChanged()
        {
            List<GetAllUsersDto> usersList = await _mediator.Send(new GetAllUsersQuery());
            await Clients.All.SendAsync("GetNewUsersList", usersList);
        }
    }
}