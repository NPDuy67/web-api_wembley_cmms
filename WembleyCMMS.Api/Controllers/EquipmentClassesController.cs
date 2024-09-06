﻿using WembleyCMMS.Api.Application.Commands.EquipmentClasses;
using WembleyCMMS.Api.Application.Queries.EquipmentClasses;

namespace WembleyCMMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipmentClassesController : ApiControllerBase
    {
        public EquipmentClassesController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        public async Task<IActionResult> CreateEquipmentClass([FromBody] CreateEquipmentClassCommand command)
        {
            return await CommandAsync(command);
        }

        [HttpGet]
        public async Task<QueryResult<EquipmentClassViewModel>> GetEquipmentClasses([FromQuery] EquipmentClassesQuery query)
        {
            return await _mediator.Send(query);
        }

        [HttpPut]
        [Route("{equipmentClassId}")]
        public async Task<IActionResult> UpdateEquipmentClass([FromRoute] string equipmentClassId, [FromBody] UpdateEquipmentClassViewModel equipmentClass)
        {
            var command = new UpdateEquipmentClassCommand(equipmentClassId, equipmentClass.Name);
            return await CommandAsync(command);
        }

        [HttpDelete]
        [Route("{equipmentClassId}")]
        public async Task<IActionResult> DeleteEquipmentClass([FromRoute] string equipmentClassId)
        {
            var command = new DeleteEquipmentClassCommand(equipmentClassId);
            return await CommandAsync(command);
        }
    }
}
