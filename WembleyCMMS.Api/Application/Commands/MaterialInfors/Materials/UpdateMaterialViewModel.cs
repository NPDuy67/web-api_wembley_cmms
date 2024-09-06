using System.Runtime.Serialization;
using static WembleyCMMS.Domain.AggregateModels.MaterialInforAggregate.Material;

namespace WembleyCMMS.Api.Application.Commands.MaterialInfors.Materials
{
    [DataContract]
    public class UpdateMaterialViewModel
    {
        public EMaterialStatus Status { get; set; }

        public UpdateMaterialViewModel(EMaterialStatus status)
        {
            Status = status;
        }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private UpdateMaterialViewModel() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    }
}
