using Microsoft.AspNetCore.Authorization;
using WembleyCMMS.Api.Application.Commands.MaintenanceRequests;
using WembleyCMMS.Api.Application.Commands.MaintenanceRequests.MaintenanceRequestStandards;
using WembleyCMMS.Api.Application.Queries.MaintenanceRequests;

namespace WembleyCMMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaintenanceRequestsController : ApiControllerBase
    {
        public MaintenanceRequestsController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        public async Task<IActionResult> CreateMaintenanceRequest([FromBody] CreateMaintenanceRequestCommand command)
        {
            return await CommandAsync(command);
        }

        [HttpGet]
        public async Task<QueryResult<MaintenanceRequestViewModel>> GetMaintenanceRequests([FromQuery] MaintenanceRequestsQuery query)
        {
            return await _mediator.Send(query);
        }

        [HttpGet]
        [Route("{maintenanceRequestId}")]
        public async Task<QueryResult<MaintenanceRequestViewModel>> GetMaintenanceRequestById([FromRoute] string maintenanceRequestId)
        {
            var query = new MaintenanceRequestByIdQuery(maintenanceRequestId);
            return await _mediator.Send(query);
        }

        [Authorize(Roles = "Manager")]
        [HttpPut]
        [Route("{maintenanceRequestId}")]
        public async Task<IActionResult> UpdateMaintenanceRequest([FromRoute] string maintenanceRequestId, [FromBody] UpdateMaintenanceRequestViewModel maintenanceRequest)
        {
            var command = new UpdateMaintenanceRequestCommand(maintenanceRequestId, maintenanceRequest.Code, maintenanceRequest.Problem,
                            maintenanceRequest.RequestedCompletionDate, maintenanceRequest.RequestedPriority, maintenanceRequest.Requester,
                            maintenanceRequest.Status, maintenanceRequest.Reviewer, maintenanceRequest.SubmissionDate, maintenanceRequest.Type, maintenanceRequest.EquipmentClass,
                            maintenanceRequest.Equipment, maintenanceRequest.Images, maintenanceRequest.ResponsiblePerson,
                            maintenanceRequest.EstProcessingTime, maintenanceRequest.PlannedStart);
            return await CommandAsync(command);
        }

        [HttpDelete]
        [Route("{maintenanceRequestId}")]
        public async Task<IActionResult> DeleteMaintenanceRequest([FromRoute] string maintenanceRequestId)
        {
            var command = new DeleteMaintenanceRequestCommand(maintenanceRequestId);
            return await CommandAsync(command);
        }

        [HttpPost]
        [Route("standard/{equipmentClassId}")]
        public async Task<IActionResult> CreateMaintenanceRequestStandard([FromRoute] string equipmentClassId, [FromBody] CreateMaintenanceRequestStandardViewModel maintenanceRequest)
        {
            var command = new CreateMaintenanceRequestStandardCommand(equipmentClassId, maintenanceRequest.Problem, maintenanceRequest.Requester, maintenanceRequest.EstProcessingTime, maintenanceRequest.StartTime, maintenanceRequest.EndTime, maintenanceRequest.MaintenanceCycle);
            return await CommandAsync(command);
        }

        [Authorize(Roles = "Manager")]
        [HttpPut]
        [Route("standard/{equipmentClassId}")]
        public async Task<IActionResult> UpdateMaintenanceRequestStandard([FromRoute] string equipmentClassId, [FromBody] UpdateMaintenanceRequestStandardViewModel maintenanceRequest)
        {
            var command = new UpdateMaintenanceRequestStandardCommand(equipmentClassId, maintenanceRequest.Status);
            return await CommandAsync(command);
        }
    }
}
