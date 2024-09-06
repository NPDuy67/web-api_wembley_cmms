using WembleyCMMS.Api.Application.Commands.WorkingTimes;
using WembleyCMMS.Api.Application.Queries.WorkingTimes;

namespace WembleyCMMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkingTimesController : ApiControllerBase
    {
        public WorkingTimesController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        public async Task<IActionResult> CreateWorkingTime([FromBody] CreateWorkingTimeCommand command)
        {
            return await CommandAsync(command);
        }

        [HttpGet]
        public async Task<QueryResult<WorkingTimeViewModel>> GetWorkingTimes([FromQuery] WorkingTimesQuery query)
        {
            return await _mediator.Send(query);
        }

        [HttpGet]
        [Route("{workingTimeId}")]
        public async Task<QueryResult<WorkingTimeViewModel>> GetWorkingTimeById([FromRoute] string workingTimeId)
        {
            var query = new WorkingTimeByIdQuery(workingTimeId);
            return await _mediator.Send(query);
        }

        [HttpPut]
        [Route("{workingTimeId}")]
        public async Task<IActionResult> UpdateWorkingTime([FromRoute] string workingTimeId, [FromBody] UpdateWorkingTimeViewModel workingTime)
        {
            var command = new UpdateWorkingTimeCommand(workingTimeId, workingTime.From, workingTime.To);
            return await CommandAsync(command);
        }

        [HttpDelete]
        [Route("{workingTimeId}")]
        public async Task<IActionResult> DeleteWorkingTime([FromRoute] string workingTimeId)
        {
            var command = new DeleteWorkingTimeCommand(workingTimeId);
            return await CommandAsync(command);
        }
    }
}
