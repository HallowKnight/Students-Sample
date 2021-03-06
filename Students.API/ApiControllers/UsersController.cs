using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Students.Application.Users.Commands.AddUserLesson;
using Students.Application.Users.Commands.AddUserRole;
using Students.Application.Users.Commands.CreateUser;
using Students.Application.Users.Commands.DeleteUser;
using Students.Application.Users.Commands.RemoveUserLesson;
using Students.Application.Users.Commands.RemoveUserRole;
using Students.Application.Users.Commands.UpdateUser;
using Students.Application.Users.Queries.GetAllUsers;
using Students.Application.Users.Queries.GetUser;
using Students.Domain.AggregatesModel.UserAggregate;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Students.Presentation.ApiControllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
           
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<User>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<GetAllUsersDto>>> GetAllUsersAsync()
        {
            return await _mediator.Send(new GetAllUsersQuery());
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(User))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GetUserDto>> GetUserByIdAsync(int userId)
        {
            return await _mediator.Send(new GetUserQuery() {UserId = userId});
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<int>> AddUserAsync([FromForm] string userName)
        {
            var result = await _mediator.Send(new CreateUserCommand() {UserName = userName});
            //await _hub.Clients.All.SendAsync("GetNewUsersList",await _mediator.Send(new GetAllUsersQuery()));
            return result;
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<int>> AddLessonToUser([FromForm] int userId, [FromForm] int lessonId)
        {
            return await _mediator.Send(new AddUserLessonCommand() {LessonId = lessonId, UserId = userId});
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<int>> AddRoleToUserAsync([FromForm] int userId, [FromForm] int roleId)
        {
            return await _mediator.Send(new AddUserRoleCommand() {UserId = userId, RoleId = roleId});
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<int>> UpdateUserByUserId([FromForm] int userId, [FromForm] string studentName)
        {
            var result = await _mediator.Send(new UpdateUserCommand() {UserId = userId, UserNewName = studentName});
            return result;
        }


        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<int>> RemoveRoleFromUser([FromForm] int userId, [FromForm] int roleId)
        {
            return await _mediator.Send(new RemoveUserRoleCommand() {UserId = userId, RoleId = roleId});
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<int>> RemoveLessonFromUser(int userId, int lessonId)
        {
            return await _mediator.Send(new RemoveUserLessonCommand() {LessonId = lessonId, UserId = userId});
        }
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<int>> DeleteUser(int userId)
        {
            var result = await _mediator.Send(new DeleteUserCommand() {UserId = userId});
            
            return result;
        }

      
    }
}