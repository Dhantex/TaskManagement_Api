using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TaskManagement.Application.Features.Categories.Commands.CreateCategory;
using TaskManagement.Application.Features.Categories.Queries.GetCategoriesList;

namespace TaskManagement.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CategoryController : ControllerBase
    {
        private IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(Name = "CreateCategory")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> CreateCategory([FromBody] CreateCategoryCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpGet(Name = "GetAllCategories")]
        [ProducesResponseType(typeof(IEnumerable<CategoriesList>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<CategoriesList>>> GetAllCategories()
        {
            var query = new GetCategoriesQuery(null);
            var videos = await _mediator.Send(query);
            return Ok(videos);
        }
    }
}
