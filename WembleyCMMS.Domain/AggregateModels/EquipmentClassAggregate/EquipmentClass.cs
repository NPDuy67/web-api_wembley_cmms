using WembleyCMMS.Domain.AggregateModels.EquipmentAggregate;

namespace WembleyCMMS.Domain.AggregateModels.EquipmentClassAggregate
{
    public class EquipmentClass : Entity, IAggregateRoot
    {
        public string EquipmentClassId { get; set; }
        public string Name { get; set; }
        public List<Equipment> Equipments { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private EquipmentClass() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        public EquipmentClass(string equipmentClassId, string name)
        {
            EquipmentClassId = equipmentClassId;
            Name = name;
            Equipments = new List<Equipment>();
        }

        public void Update(string name)
        {
            Name = name;
        }
    }
}
