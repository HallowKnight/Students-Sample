using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Students.Application.Schools.Commands.CreateClass;
using Students.Application.Schools.Commands.CreateSchool;
using Students.Application.Schools.Commands.DeleteClass;
using Students.Application.Schools.Commands.DeleteSchool;
using Students.Application.Schools.Commands.UpdateClass;
using Students.Application.Schools.Commands.UpdateSchool;
using Students.Application.Schools.Queries.GetAllClasses;
using Students.Application.Schools.Queries.GetAllSchools;
using Students.Application.Schools.Queries.GetClass;
using Students.Application.Schools.Queries.GetSchool;
using Students.Application.Schools.Queries.GetSchoolClasses;

namespace Students.Presentation.ApiControllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class SchoolsController : Controller
    {
        private readonly IMediator _mediator;

        public SchoolsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<GetAllSchoolsDto>>> GetAllSchoolsAsync()
        {
            return await _mediator.Send(new GetAllSchoolsQuery());
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<GetSchoolDto>> GetSchoolByIdAsync( int schoolId)
        {
            return await _mediator.Send(new GetSchoolQuery() {SchoolId = schoolId});
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<GetAllClassesDto>>> GetAllClassesAsync()
        {
            return await _mediator.Send(new GetAllClassesQuery());
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<GetClassDto>> GetClassByIdAsync( int classId)
        {
            return await _mediator.Send(new GetClassQuery() {ClassId = classId});
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<GetSchoolClassesDto>>> GetSchoolClassesAsync( int schoolId)
        {
            return await _mediator.Send(new GetSchoolClassesQuery() {SchoolId = schoolId});
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<int>> CreateSchoolAsync([FromForm] string schoolTitle)
        {
            return await _mediator.Send(new CreateSchoolCommand() {SchoolTitle = schoolTitle});
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<int>> UpdateSchool([FromForm] string schoolTitle,[FromForm] int schoolId)
        {
            return await _mediator.Send(new UpdateSchoolCommand() {SchoolTitle = schoolTitle,SchoolId = schoolId});
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<int>> DeleteSchool([FromForm] int schoolId)
        {
            return await _mediator.Send(new DeleteSchoolCommand() {SchoolId = schoolId});
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<int>> AddClassAsync([FromForm] string classTitle,[FromForm]int schoolId)
        {
            return await _mediator.Send(new CreateClassCommand() {ClassTitle = classTitle,SchoolId = schoolId});
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<int>> UpdateClass([FromForm] string classTitle,[FromForm] int classId)
        {
            return await _mediator.Send(new UpdateClassCommand() {ClassTitle = classTitle,ClassId = classId});
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<int>> DeleteClass([FromForm] int classId)
        {
            return await _mediator.Send(new DeteleClassCommand() {ClassId = classId});
        }
    }
}