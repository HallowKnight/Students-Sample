//using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.SignalR;
//using Students.Application.Common.Hubs;
using Students.Application.Users.Queries.GetAllUsers;

namespace Students.Presentation.Controllers
{
    public class UsersListController : Controller
    {
        private readonly IMediator _mediator;
        //private readonly IHubContext<UsersListHub> _hub;

        
        public UsersListController(IMediator mediator/*, IHubContext<UsersListHub> hub*/)
        {
            _mediator = mediator;
            //_hub = hub;

        }
        
        public async Task<IActionResult> Index()
        {
            var result = await _mediator.Send(new GetAllUsersQuery());
            //await _hub.Clients.All.SendAsync("GetNewUsersList",result);
            return View(result);
        }
    }
}