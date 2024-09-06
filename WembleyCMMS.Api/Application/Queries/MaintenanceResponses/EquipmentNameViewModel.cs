namespace WembleyCMMS.Api.Application.Queries.MaintenanceResponses
{
    public class EquipmentNameViewModel
    {
        public string EquipmentId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }

        public EquipmentNameViewModel(string equipmentId, string code, string name)
        {
            EquipmentId = equipmentId;
            Code = code;
            Name = name;
        }
    }
}
