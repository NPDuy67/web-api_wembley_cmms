using static WembleyCMMS.Domain.AggregateModels.MaterialInforAggregate.Material;

namespace WembleyCMMS.Api.Application.Commands.MaterialInfors.Materials
{
    public class UpdateMaterialCommand : IRequest<bool>
    {
        public string MaterialId { get; set; }
        public string MaterialInforId { get; set; }
        public EMaterialStatus Status { get; set; }

        public UpdateMaterialCommand(string materialId, string materialInforId, EMaterialStatus status)
        {
            MaterialId = materialId;
            MaterialInforId = materialInforId;
            Status = status;
        }
    }
}
