using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TaskManagement.Application.Features.GenericTasks.Commands.CreateGenericTask;
using TaskManagement.Application.Features.GenericTasks.Commands.DeleteGenericTask;
using TaskManagement.Application.Features.GenericTasks.Commands.UpdateGenericTask;
using TaskManagement.Application.Features.GenericTasks.Queries.GetGenericTaskDetailsList;

namespace TaskManagement.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class GenericTaskController: ControllerBase
    {
        private readonly IMediator _mediator;

        public GenericTaskController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(Name = "CreateGenericTask")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> CreateGenericTask([FromBody] CreateGenericTaskCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpPut(Name = "UpdateGenericTask")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateGenericTask([FromBody] UpdateGenericTaskCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteGenericTask")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteGenericTask(int id)
        {
            var command = new DeleteGenericTaskCommand
            {
                Id = id
            };

            await _mediator.Send(command);

            return NoContent();
        }

        [HttpGet("{categoryId:int}", Name = "GetGenericTaskDetailsById")]
        [ProducesResponseType(typeof(IEnumerable<GenericTaskDetail>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<GenericTaskDetail>>> GetGenericTaskDetailsById(int categoryId)
        {
            var query = new GetGenericTaskDetailQuery(null, categoryId);
            var videos = await _mediator.Send(query);
            return Ok(videos);
        }

        [HttpGet("details/{categoryName?}", Name = "GetGenericTaskDetails")]
        [ProducesResponseType(typeof(IEnumerable<GenericTaskDetail>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<GenericTaskDetail>>> GetGenericTaskDetails(string? categoryName = null)
        {
            var query = new GetGenericTaskDetailQuery(categoryName!, 0);
            var videos = await _mediator.Send(query);
            return Ok(videos);
        }

        [HttpGet("details/all", Name = "GetAllGenericTaskDetails")]
        [ProducesResponseType(typeof(IEnumerable<GenericTaskDetail>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<GenericTaskDetail>>> GetGenericTaskDetails()
        {
            var query = new GetGenericTaskDetailQuery(null,0);
            var videos = await _mediator.Send(query);
            return Ok(videos);
        }
    }
}
