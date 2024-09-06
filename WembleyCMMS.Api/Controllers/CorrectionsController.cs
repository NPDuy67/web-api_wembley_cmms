using WembleyCMMS.Api.Application.Commands.Corrections;
using WembleyCMMS.Api.Application.Queries.Corrections;

namespace WembleyCMMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CorrectionsController : ApiControllerBase
    {
        public CorrectionsController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        public async Task<IActionResult> CreateCorrection([FromBody] CreateCorrectionCommand command)
        {
            return await CommandAsync(command);
        }

        [HttpGet]
        public async Task<QueryResult<CorrectionViewModel>> GetCorrections([FromQuery] CorrectionsQuery query)
        {
            return await _mediator.Send(query);
        }

        [HttpGet]
        [Route("{correctionId}")]
        public async Task<QueryResult<CorrectionViewModel>> GetCorrectionById([FromRoute] string correctionId)
        {
            var query = new CorrectionByIdQuery(correctionId);
            return await _mediator.Send(query);
        }

        [HttpPut]
        [Route("{correctionId}")]
        public async Task<IActionResult> UpdateCorrection([FromRoute] string correctionId, [FromBody] UpdateCorrectionViewModel correction)
        {
            var command = new UpdateCorrectionCommand(correctionId, correction.CorrectionCode, correction.CorrectionName, correction.CorrectionType, correction.EstProcessTime, correction.Note);
            return await CommandAsync(command);
        }

        [HttpDelete]
        [Route("{correctionId}")]
        public async Task<IActionResult> DeleteCorrection([FromRoute] string correctionId)
        {
            var command = new DeleteCorrectionCommand(correctionId);
            return await CommandAsync(command);
        }
    }
}
