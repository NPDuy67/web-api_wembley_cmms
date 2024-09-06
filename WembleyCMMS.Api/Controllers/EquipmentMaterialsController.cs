using WembleyCMMS.Api.Application.Commands.EquipmentMaterials;
using WembleyCMMS.Api.Application.Queries.EquipmentMaterials;
using WembleyCMMS.Api.Application.Queries;
using WembleyCMMS.Api.Application.Queries.EquipmentEquipmentMaterials;
using System.Runtime.InteropServices;
using System.Linq;

namespace WembleyCMMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipmentMaterialsController : ApiControllerBase
    {

        public EquipmentMaterialsController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        public async Task<QueryResult<EquipmentMaterialViewModel>> GetEquipmentMaterials([FromQuery] EquipmentMaterialsQuery query)
        {
            return await _mediator.Send(query);
        }

        [HttpPost]
        [Route("Equipments/{equipmentId}")]
        public async Task<IActionResult> CreateEquipmentMaterial([FromRoute] string equipmentId, [FromBody] CreateEquipmentMaterialViewModel equipmentMaterial)
        {
            var command = new CreateEquipmentMaterialCommand(equipmentId, equipmentMaterial.MaterialInforId, equipmentMaterial.FullTime);
            return await CommandAsync(command);
        }

        [HttpGet]
        [Route("Equipments/{equipmentId}")]
        public async Task<QueryResult<EquipmentMaterialViewModel>> GetEquipmentMaterialByEquipmentId([FromRoute] string equipmentId)
        {
            var query = new EquipmentMaterialByEquipmentIdQuery(equipmentId);
            return await _mediator.Send(query);
        }

        [HttpGet]
        [Route("{equipmentMaterialId}")]
        public async Task<QueryResult<EquipmentMaterialViewModel>> GetEquipmentMaterialById([FromRoute] string equipmentMaterialId)
        {
            var query = new EquipmentMaterialByIdQuery(equipmentMaterialId);
            return await _mediator.Send(query);
        }

        [HttpPut]
        [Route("{equipmentMaterialId}")]
        public async Task<IActionResult> UpdateEquipmentMaterial([FromRoute] string equipmentMaterialId, [FromBody] UpdateEquipmentMaterialViewModel equipmentMaterial)
        {
            var command = new UpdateEquipmentMaterialCommand(equipmentMaterialId, equipmentMaterial.MaterialInforId, equipmentMaterial.FullTime, equipmentMaterial.UsedTime, equipmentMaterial.InstalledTime);
            return await CommandAsync(command);
        }

        [HttpDelete]
        [Route("{equipmentMaterialId}")]
        public async Task<IActionResult> DeleteEquipmentMaterial([FromRoute] string equipmentMaterialId)
        {
            var command = new DeleteEquipmentMaterialCommand(equipmentMaterialId);
            return await CommandAsync(command);
        }
    }
}
