﻿using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Students.Domain.AggregatesModel.RoleAggregate;
using Students.Domain.AggregatesModel.UserAggregate;

namespace Students.Application.Users.Commands.RemoveUserRole
{
    public class RemoveUserRoleCommandHandler : IRequestHandler<RemoveUserRoleCommand,int>
    {


        private readonly IUserCommands _userCommands;

        public RemoveUserRoleCommandHandler(IUserCommands userCommands)
        {
            _userCommands = userCommands;
        }
        
        public async Task<int> Handle(RemoveUserRoleCommand request, CancellationToken cancellationToken)
        {
            _userCommands.RemoveRoleFromUser(request.UserId,request.RoleId);
            request.transctionCount++;
            return request.transctionCount;
        }
    }
}