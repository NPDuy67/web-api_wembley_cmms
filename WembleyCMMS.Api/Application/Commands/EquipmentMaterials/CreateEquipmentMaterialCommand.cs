namespace WembleyCMMS.Api.Application.Commands.EquipmentMaterials
{
    public class CreateEquipmentMaterialCommand : IRequest<bool>
    {
        public string EquipmentId { get; set; }
        public string MaterialInforId { get; set; }
        public decimal FullTime { get; set; }

        public CreateEquipmentMaterialCommand(string equipmentId, string materialInforId, decimal fullTime)
        {
            EquipmentId = equipmentId;
            MaterialInforId = materialInforId;
            FullTime = fullTime;
        }
    }
}
