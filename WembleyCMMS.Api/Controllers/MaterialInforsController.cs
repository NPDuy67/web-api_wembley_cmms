using WembleyCMMS.Api.Application.Commands.MaterialInfors;
using WembleyCMMS.Api.Application.Commands.MaterialInfors.MaterialHistoryCards;
using WembleyCMMS.Api.Application.Commands.MaterialInfors.MaterialRequests;
using WembleyCMMS.Api.Application.Commands.MaterialInfors.Materials;
using WembleyCMMS.Api.Application.Queries.MaterialInfors;
using WembleyCMMS.Api.Application.Queries.MaterialInfors.MaterialHistoryCards;
using WembleyCMMS.Api.Application.Queries.MaterialInfors.MaterialRequests;
using WembleyCMMS.Api.Application.Queries.MaterialInfors.Materials;
using static WembleyCMMS.Domain.AggregateModels.MaterialInforAggregate.Material;

namespace WembleyCMMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialInforsController : ApiControllerBase
    {
        public MaterialInforsController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        public async Task<IActionResult> CreateMaterialInfor([FromBody] CreateMaterialInforCommand command)
        {
            return await CommandAsync(command);
        }

        [HttpGet]
        public async Task<QueryResult<MaterialInforViewModel>> GetMaterialInfors([FromQuery] MaterialInforsQuery query)
        {
            return await _mediator.Send(query);
        }

        [HttpGet]
        [Route("{materialInforId}")]
        public async Task<QueryResult<MaterialInforViewModel>> GetMaterialInforById([FromRoute] string materialInforId)
        {
            var query = new MaterialInforByIdQuery(materialInforId);
            return await _mediator.Send(query);
        }

        [HttpPut]
        [Route("{materialInforId}")]
        public async Task<IActionResult> UpdateMaterialInfor([FromRoute] string materialInforId, [FromBody] UpdateMaterialInforViewModel materialInfor)
        {
            var command = new UpdateMaterialInforCommand(materialInforId, materialInfor.Code, materialInfor.Name, materialInfor.Unit, materialInfor.MinimumQuantity);
            return await CommandAsync(command);
        }

        [HttpDelete]
        [Route("{materialInforId}")]
        public async Task<IActionResult> DeleteMaterialInfor([FromRoute] string materialInforId)
        {
            var command = new DeleteMaterialInforCommand(materialInforId);
            return await CommandAsync(command);
        }

        [HttpPost]
        [Route("{materialInforId}/MaterialHistoryCards")]
        public async Task<IActionResult> CreateMaterialHistoryCard([FromRoute] string materialInforId, [FromBody] CreateMaterialHistoryCardViewModel materialHistoryCard)
        {
            var command = new CreateMaterialHistoryCardCommand(materialInforId, materialHistoryCard.TimeStamp, materialHistoryCard.Before, materialHistoryCard.Input, materialHistoryCard.Output, materialHistoryCard.After, materialHistoryCard.Note);
            return await CommandAsync(command);
        }

        [HttpGet]
        [Route("{materialInforId}/MaterialHistoryCards")]
        public async Task<QueryResult<MaterialHistoryCardViewModel>> GetMaterialHistoryCards([FromRoute] string materialInforId)
        {
            var query = new MaterialHistoryCardsQuery(materialInforId);
            return await _mediator.Send(query);
        }

        //[HttpGet]
        //[Route("MaterialHistoryCards/{materialHistoryCardId}")]
        //public async Task<QueryResult<MaterialHistoryCardViewModel>> GetMaterialHistoryCardById([FromRoute] string materialHistoryCardId)
        //{
        //    var query = new MaterialHistoryCardByIdQuery(materialHistoryCardId);
        //    return await _mediator.Send(query);
        //}

        [HttpPut]
        [Route("{materialInforId}/MaterialHistoryCards/{materialHistoryCardId}")]
        public async Task<IActionResult> UpdateMaterialHistoryCard([FromRoute] string materialInforId, [FromRoute] string materialHistoryCardId, [FromBody] UpdateMaterialHistoryCardViewModel materialHistoryCard)
        {
            var command = new UpdateMaterialHistoryCardCommand(materialInforId, materialHistoryCardId, materialHistoryCard.TimeStamp, materialHistoryCard.Before, materialHistoryCard.Input, materialHistoryCard.Output, materialHistoryCard.After, materialHistoryCard.Note);
            return await CommandAsync(command);
        }

        [HttpDelete]
        [Route("{materialInforId}/MaterialHistoryCards/{materialHistoryCardId}")]
        public async Task<IActionResult> DeleteMaterialHistoryCard([FromRoute] string materialInforId, [FromRoute] string materialHistoryCardId)
        {
            var command = new DeleteMaterialHistoryCardCommand(materialInforId, materialHistoryCardId);
            return await CommandAsync(command);
        }

        [HttpPost]
        [Route("{materialInforId}/Materials")]
        public async Task<IActionResult> CreateMaterial([FromRoute] string materialInforId, [FromBody] CreateMaterialViewModel material)
        {
            var command = new CreateMaterialCommand(material.Sku, materialInforId);
            return await CommandAsync(command);
        }

        [HttpGet]
        [Route("{materialInforId}/Materials")]
        public async Task<QueryResult<MaterialViewModel>> GetMaterials([FromRoute] string materialInforId, [FromQuery] EMaterialStatus? status)
        {
            var query = new MaterialsQuery(materialInforId, status);
            return await _mediator.Send(query);
        }

        [HttpGet]
        [Route("{materialInforId}/Materials/{materialId}")]
        public async Task<QueryResult<MaterialViewModel>> GetMaterialById([FromRoute] string materialInforId, [FromRoute] string materialId)
        {
            var query = new MaterialByIdQuery(materialInforId, materialId);
            return await _mediator.Send(query);
        }

        [HttpPut]
        [Route("{materialInforId}/Materials/{materialId}")]
        public async Task<IActionResult> UpdateMaterial([FromRoute] string materialInforId, [FromRoute] string materialId, [FromBody] UpdateMaterialViewModel material)
        {
            var command = new UpdateMaterialCommand(materialId, materialInforId, material.Status);
            return await CommandAsync(command);
        }

        [HttpDelete]
        [Route("{materialInforId}/Materials/{materialId}")]
        public async Task<IActionResult> DeleteMaterial([FromRoute] string materialInforId, [FromRoute] string materialId)
        {
            var command = new DeleteMaterialCommand(materialInforId, materialId);
            return await CommandAsync(command);
        }

        [HttpGet]
        [Route("{materialInforId}/Materials/Sku/{sku}")]
        public async Task<QueryResult<MaterialViewModel>> GetMaterialBySku([FromRoute] string materialInforId, [FromRoute] string sku)
        {
            var query = new MaterialBySkuQuery(materialInforId, sku);
            return await _mediator.Send(query);
        }

        [HttpPost]
        [Route("{materialInforId}/MaterialRequests")]
        public async Task<IActionResult> CreateMaterialRequest([FromRoute] string materialInforId, [FromBody] CreateMaterialRequestViewModel materialRequest)
        {
            var command = new CreateMaterialRequestCommand(materialInforId, materialRequest.AdditionalNumber, materialRequest.ExpectedNumber, materialRequest.ExpectedDate);
            return await CommandAsync(command);
        }

        [HttpGet]
        [Route("{materialInforId}/MaterialRequests")]
        public async Task<QueryResult<MaterialRequestViewModel>> GetMaterialRequests([FromRoute] string materialInforId, [FromQuery] MaterialRequestsFromQuery fromQuery)
        {
            var query = new MaterialRequestsQuery(materialInforId, fromQuery.StartDate, fromQuery.EndDate, fromQuery.Status);
            return await _mediator.Send(query);
        }

        [HttpGet]
        [Route("{materialInforId}/MaterialRequests/{materialRequestId}")]
        public async Task<QueryResult<MaterialRequestViewModel>> GetMaterialRequestById([FromRoute] string materialInforId, [FromRoute] string materialRequestId)
        {
            var query = new MaterialRequestByIdQuery(materialInforId, materialRequestId);
            return await _mediator.Send(query);
        }

        [HttpPut]
        [Route("{materialInforId}/MaterialRequests/{materialRequestId}")]
        public async Task<IActionResult> UpdateMaterialRequest([FromRoute] string materialInforId, [FromRoute] string materialRequestId, [FromBody] UpdateMaterialRequestViewModel materialRequest)
        {
            var command = new UpdateMaterialRequestCommand(materialRequestId, materialInforId, materialRequest.CurrentNumber, materialRequest.AdditionalNumber, materialRequest.ExpectedNumber, materialRequest.ExpectedDate, materialRequest.Status);
            return await CommandAsync(command);
        }

        [HttpDelete]
        [Route("{materialInforId}/MaterialRequests/{materialRequestId}")]
        public async Task<IActionResult> DeleteMaterialRequest([FromRoute] string materialInforId, [FromRoute] string materialRequestId)
        {
            var command = new DeleteMaterialRequestCommand(materialInforId, materialRequestId);
            return await CommandAsync(command);
        }
    }
}
