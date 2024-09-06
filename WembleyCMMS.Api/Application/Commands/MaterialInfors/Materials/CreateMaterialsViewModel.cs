using System.Runtime.Serialization;
using static WembleyCMMS.Domain.AggregateModels.MaterialInforAggregate.Material;

namespace WembleyCMMS.Api.Application.Commands.MaterialInfors.Materials
{
    [DataContract]
    public class CreateMaterialsViewModel
    {
        public string Sku { get; set; }
        public string MaterialInforId { get; set; }
        public EMaterialStatus Status { get; set; }

        public CreateMaterialsViewModel(string sku, string materialInforId, EMaterialStatus status)
        {
            Sku = sku;
            MaterialInforId = materialInforId;
            Status = status;
        }
    }
}

