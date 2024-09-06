using WembleyCMMS.Api.Application.Commands.PerformanceIndexs;
using WembleyCMMS.Api.Application.Queries.PerformanceIndexs;

namespace WembleyCMMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerformanceIndexsController : ApiControllerBase
    {

        public PerformanceIndexsController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        public async Task<IActionResult> CreatePerformanceIndex([FromBody] CreatePerformanceIndexCommand command)
        {
            return await CommandAsync(command);
        }

        [HttpGet]
        public async Task<QueryResult<PerformanceIndexViewModel>> GetPerformanceIndexs([FromQuery] PerformanceIndexsQuery query)
        {
            return await _mediator.Send(query);
        }

        [HttpGet]
        [Route("{performanceIndexId}")]
        public async Task<QueryResult<PerformanceIndexViewModel>> GetPerformanceIndexById([FromRoute] string performanceIndexId)
        {
            var query = new PerformanceIndexByIdQuery(performanceIndexId);
            return await _mediator.Send(query);
        }

        [HttpPut]
        [Route("{performanceIndexId}")]
        public async Task<IActionResult> UpdatePerformanceIndex([FromRoute] string performanceIndexId, [FromBody] UpdatePerformanceIndexViewModel performanceIndex)
        {
            var command = new UpdatePerformanceIndexCommand(performanceIndexId, performanceIndex.IsTracking, performanceIndex.RecentValue, performanceIndex.History, performanceIndex.MaxLength);
            return await CommandAsync(command);
        }

        [HttpDelete]
        [Route("{performanceIndexId}")]
        public async Task<IActionResult> DeletePerformanceIndex([FromRoute] string performanceIndexId)
        {
            var command = new DeletePerformanceIndexCommand(performanceIndexId);
            return await CommandAsync(command);
        }
    }
}
