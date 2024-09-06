using System.Runtime.Serialization;

namespace WembleyCMMS.Api.Application.Commands.EquipmentMaterials
{
    [DataContract]
    public class UpdateEquipmentMaterialViewModel
    {
        public string MaterialInforId { get; set; }
        public decimal FullTime { get; set; }
        public decimal UsedTime { get; set; }
        public DateTime InstalledTime { get; set; }

        public UpdateEquipmentMaterialViewModel(string materialInforId, decimal fullTime, decimal usedTime, DateTime installedTime)
        {
            MaterialInforId = materialInforId;
            FullTime = fullTime;
            UsedTime = usedTime;
            InstalledTime = installedTime;
        }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private UpdateEquipmentMaterialViewModel() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    }
}
