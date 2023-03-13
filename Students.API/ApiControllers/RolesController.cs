using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Students.Application.Roles.Commands.CreateRole;
using Students.Application.Roles.Commands.DeleteRole;
using Students.Application.Roles.Commands.UpdateRole;
using Students.Application.Roles.Queries.GetAllRoles;
using Students.Application.Roles.Queries.GetRole;
using Students.Application.Roles.Queries.GetRoleUsers;
using Students.Application.Roles.Queries.GetUserRoles;

namespace Students.Presentation.ApiControllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class RolesController : Controller
    {
        private readonly IMediator _mediator;

        public RolesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<GetAllRolesDto>>> GetAllRolesAsync()
        {
            return await _mediator.Send(new GetAllRolesQuery());
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<GetRoleDto>> GetRoleByIdAsync(int roleId)
        {
            return await _mediator.Send(new GetRoleQuery { RoleId = roleId });
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<GetRoleUsersDto>>> GetRoleUsersAsync(int roleId)
        {
            return await _mediator.Send(new GetRoleUsersQuery { RoleId = roleId });
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<GetUserRolesDto>>> GetUserRolesAsync(int userId)
        {
            return await _mediator.Send(new GetUserRolesQuery { UserId = userId });
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        public async Task<ActionResult<int>> AddRoleAsync([FromForm] string roleTitle)
        {
            return await _mediator.Send(new CreateRoleCommand { RoleTitle = roleTitle });
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        public async Task<ActionResult<int>> UpdateRole([FromForm] int roleId, [FromForm] string newRoleTitle)
        {
            return await _mediator.Send(new UpdateRoleCommand { NewTitle = newRoleTitle, RoleId = roleId });
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        public async Task<ActionResult<int>> DeleteRole([FromForm] int roleId)
        {
            return await _mediator.Send(new DeleteRoleCommand { RoleId = roleId });
        }
    }
}