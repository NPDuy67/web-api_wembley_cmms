namespace WembleyCMMS.Api.Application.Commands.EquipmentMaterials
{
    public class UpdateEquipmentMaterialCommand : IRequest<bool>
    {
        public string EquipmentMaterialId { get; set; }
        public string MaterialInforId { get; set; }
        public decimal FullTime { get; set; }
        public decimal UsedTime { get; set; }
        public DateTime InstalledTime { get; set; }

        public UpdateEquipmentMaterialCommand(string equipmentMaterialId, string materialInforId, decimal fullTime, decimal usedTime, DateTime installedTime)
        {
            EquipmentMaterialId = equipmentMaterialId;
            MaterialInforId = materialInforId;
            FullTime = fullTime;
            UsedTime = usedTime;
            InstalledTime = installedTime;
        }
    }
}
