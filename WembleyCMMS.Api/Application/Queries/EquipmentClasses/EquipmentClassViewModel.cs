namespace WembleyCMMS.Api.Application.Queries.EquipmentClasses
{
    public class EquipmentClassViewModel
    {
        public string EquipmentClassId { get; set; }
        public string Name { get; set; }

        public EquipmentClassViewModel(string equipmentClassId, string name)
        {
            EquipmentClassId = equipmentClassId;
            Name = name;
        }
    }
}
