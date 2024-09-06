using System.Runtime.Serialization;

namespace WembleyCMMS.Api.Application.Commands.EquipmentMaterials
{
    [DataContract]
    public class CreateEquipmentMaterialViewModel
    {
        public string MaterialInforId { get; set; }
        public decimal FullTime { get; set; }

        public CreateEquipmentMaterialViewModel(string materialInforId, decimal fullTime)
        {
            MaterialInforId = materialInforId;
            FullTime = fullTime;
        }
    }
}
