using WembleyCMMS.Api.Application.Commands.MaintenanceResponses;
using WembleyCMMS.Api.Application.Queries.MaintenanceResponses;

namespace WembleyCMMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaintenanceResponsesController : ApiControllerBase
    {
        public MaintenanceResponsesController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        public async Task<IActionResult> CreateMaintenanceResponse([FromBody] CreateMaintenanceResponseCommand command)
        {
            return await CommandAsync(command);
        }

        [HttpGet]
        public async Task<QueryResult<MaintenanceResponseViewModel>> GetMaintenanceResponses([FromQuery] MaintenanceResponsesQuery query)
        {
            return await _mediator.Send(query);
        }

        [HttpGet]
        [Route("{maintenanceResponseId}")]
        public async Task<QueryResult<MaintenanceResponseViewModel>> GetMaintenanceResponseById([FromRoute] string maintenanceResponseId)
        {
            var query = new MaintenanceResponseByIdQuery(maintenanceResponseId);
            return await _mediator.Send(query);
        }

        [HttpPut]
        [Route("{maintenanceResponseId}")]
        public async Task<IActionResult> UpdateMaintenanceResponse([FromRoute] string maintenanceResponseId, [FromBody] UpdateMaintenanceResponseViewModel maintenanceResponse)
        {
            var command = new UpdateMaintenanceResponseCommand(maintenanceResponseId: maintenanceResponseId,
                                                               cause: maintenanceResponse.Cause,
                                                               correction: maintenanceResponse.Correction,
                                                               plannedStart: maintenanceResponse.PlannedStart,
                                                               plannedFinish: maintenanceResponse.PlannedFinish,
                                                               estProcessTime: maintenanceResponse.EstProcessTime,
                                                               actualStartTime: maintenanceResponse.ActualStartTime,
                                                               actualFinishTime: maintenanceResponse.ActualFinishTime,
                                                               status: maintenanceResponse.Status,
                                                               responsiblePerson: maintenanceResponse.ResponsiblePerson,
                                                               priority: maintenanceResponse.Priority,
                                                               problem: maintenanceResponse.Problem,
                                                               images: maintenanceResponse.Images,
                                                               materials: maintenanceResponse.Materials,
                                                               code: maintenanceResponse.Code, 
                                                               note: maintenanceResponse.Note,
                                                               request: maintenanceResponse.Request,
                                                               equipmentClass: maintenanceResponse.EquipmentClass,
                                                               equipment: maintenanceResponse   .Equipment,
                                                               dueDate: maintenanceResponse.DueDate,
                                                               type: maintenanceResponse.Type,
                                                               inspectionReports: maintenanceResponse.InspectionReports);
            return await CommandAsync(command);
        }

        [HttpDelete]
        [Route("{maintenanceResponseId}")]
        public async Task<IActionResult> DeleteMaintenanceResponse([FromRoute] string maintenanceResponseId)
        {
            var command = new DeleteMaintenanceResponseCommand(maintenanceResponseId);
            return await CommandAsync(command);
        }
    }
}
