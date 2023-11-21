using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TaskManagement.Application.Features.StatusTypes.Commands.CreateStatusTypes;
using TaskManagement.Application.Features.StatusTypes.Queries;

namespace TaskManagement.Api.Controllers
{

    [ApiController]
    [Route("api/v1/[controller]")]
    public class StatusTypeController: ControllerBase
    {
        private IMediator _mediator;

        public StatusTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(Name = "CreateStatusType")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> CreateStatusType([FromBody] CreateStatusTypeCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpGet(Name = "GetAllStatusTypes")]
        [ProducesResponseType(typeof(IEnumerable<StatusTypesList>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<StatusTypesList>>> GetAllStatusTypes()
        {
            var query = new GetStatusTypesQuery(null); ;
            var videos = await _mediator.Send(query);
            return Ok(videos);
        }
    }
}
