using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Students.Application.Lessons.Commands.ComplexTestHandler;
using Students.Application.Lessons.Commands.CreateLesson;
using Students.Application.Lessons.Commands.DeleteLesson;
using Students.Application.Lessons.Commands.UpdateLesson;
using Students.Application.Lessons.Queries.GetAllLessons;
using Students.Application.Lessons.Queries.GetUserLessons;
using Students.Domain.AggregatesModel.LessonAggregate;

namespace Students.Presentation.ApiControllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class LessonsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LessonsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Lesson>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<GetAllLessonsDto>>> GetAllLessonsAsync()
        {
            return await _mediator.Send(new GetAllLessonsQuery());
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetUserLessonsQuery))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<GetUserLessonsDto>> GetUserLessonsAsync(int userId)
        {
            return await _mediator.Send(new GetUserLessonsQuery { UserId = userId });
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<int>> AddLessonAsync([FromForm] string lessonTitle)
        {
            return await _mediator.Send(new CreateLessonCommand { LessonTitle = lessonTitle });
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<int>> ComplexAction(string sName, string lName, int sId, int lId)
        {
            return await _mediator.Send(new ComplexTestHandlerCommand
            {
                UserId = sId,
                LessonId = lId,
                UserName = sName,
                LessonName = lName
            });
        }


        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<int>> DeleteLesson(int lessonId)
        {
            return await _mediator.Send(new DeleteLessonCommand { LessonId = lessonId });
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<int>> UpdateLesson(int lessonId, string newTitle)
        {
            return await _mediator.Send(new UpdateLessonCommand { LessonId = lessonId, NewTitle = newTitle });
        }
    }
}