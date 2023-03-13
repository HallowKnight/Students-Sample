using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Students.Application.Users.Queries.GetAllUsers;

namespace Students.Presentation.Controllers
{
    public class UsersListController : Controller
    {
        private readonly IMediator _mediator;


        public UsersListController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            List<GetAllUsersDto> result = await _mediator.Send(new GetAllUsersQuery());
            return View(result);
        }
    }
}