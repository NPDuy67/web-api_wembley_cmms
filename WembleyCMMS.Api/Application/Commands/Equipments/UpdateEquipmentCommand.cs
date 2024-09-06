namespace WembleyCMMS.Api.Application.Commands.Equipments
{
    public class UpdateEquipmentCommand : IRequest<bool>
    {
        public string EquipmentId { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string EquipmentClass { get; set; }

        public UpdateEquipmentCommand(string equipmentId, string? code, string? name, string equipmentClass)
        {
            EquipmentId = equipmentId;
            Code = code;
            Name = name;
            EquipmentClass = equipmentClass;
        }
    }

}
