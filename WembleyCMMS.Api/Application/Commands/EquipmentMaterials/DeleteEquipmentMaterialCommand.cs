namespace WembleyCMMS.Api.Application.Commands.EquipmentMaterials
{
    public class DeleteEquipmentMaterialCommand : IRequest<bool>
    {
        public string EquipmentMaterialId { get; set; }

        public DeleteEquipmentMaterialCommand(string equipmentMaterialId)
        {
            EquipmentMaterialId = equipmentMaterialId;
        }
    }
}
