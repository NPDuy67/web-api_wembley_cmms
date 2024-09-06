using WembleyCMMS.Api.Application.Commands.Causes;
using WembleyCMMS.Api.Application.Queries.Causes;

namespace WembleyCMMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CausesController : ApiControllerBase
    {
        public CausesController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        public async Task<IActionResult> CreateCause([FromBody] CreateCauseCommand command)
        {
            return await CommandAsync(command);
        }

        [HttpGet]
        public async Task<QueryResult<CauseViewModel>> GetCauses([FromQuery] CausesQuery query)
        {
            return await _mediator.Send(query);
        }

        [HttpGet]
        [Route("{causeId}")]
        public async Task<QueryResult<CauseViewModel>> GetCauseById([FromRoute] string causeId)
        {
            var query = new CauseByIdQuery(causeId);
            return await _mediator.Send(query);
        }

        [HttpPut]
        [Route("{causeId}")]
        public async Task<IActionResult> UpdateCause([FromRoute] string causeId, [FromBody] UpdateCauseViewModel cause)
        {
            var command = new UpdateCauseCommand(causeId, cause.CauseCode, cause.CauseName, cause.EquipmentClass, cause.Severity, cause.Note);
            return await CommandAsync(command);
        }

        [HttpDelete]
        [Route("{causeId}")]
        public async Task<IActionResult> DeleteCause([FromRoute] string causeId)
        {
            var command = new DeleteCauseCommand(causeId);
            return await CommandAsync(command);
        }
    }
}
