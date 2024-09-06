using WembleyCMMS.Api.Application.Commands.Equipments;
using WembleyCMMS.Api.Application.Queries.Equipments;

namespace WembleyCMMS.Api.Equipments
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipmentsController : ApiControllerBase
    {
        public EquipmentsController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        public async Task<IActionResult> CreateEquipment([FromBody] CreateEquipmentCommand command)
        {
            return await CommandAsync(command);
        }

        [HttpGet]
        public async Task<QueryResult<EquipmentViewModel>> GetEquipments([FromQuery] EquipmentsQuery query)
        {
            return await _mediator.Send(query);
        }

        [HttpGet]
        [Route("{equipmentId}")]
        public async Task<QueryResult<EquipmentViewModel>> GetEquipmentById([FromRoute] string equipmentId)
        {
            var query = new EquipmentByIdQuery(equipmentId);
            return await _mediator.Send(query);
        }

        [HttpPut]
        [Route("{equipmentId}")]
        public async Task<IActionResult> UpdateEquipment([FromRoute] string equipmentId, [FromBody] UpdateEquipmentViewModel equipment)
        {
            var command = new UpdateEquipmentCommand(equipmentId, equipment.Code, equipment.Name, equipment.EquipmentClass);
            return await CommandAsync(command);
        }

        [HttpDelete]
        [Route("{equipmentId}")]
        public async Task<IActionResult> DeleteEquipment([FromRoute] string equipmentId)
        {
            var command = new DeleteEquipmentCommand(equipmentId);
            return await CommandAsync(command);
        }
    }
}
