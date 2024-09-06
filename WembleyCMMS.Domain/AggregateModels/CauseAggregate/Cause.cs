using WembleyCMMS.Domain.AggregateModels.EquipmentClassAggregate;
using WembleyCMMS.Domain.AggregateModels.MaintenanceResponseAggregate;

namespace WembleyCMMS.Domain.AggregateModels.CauseAggregate
{
    public class Cause : Entity, IAggregateRoot
    {
        public string CauseId { get; set; }
        public string CauseCode { get; set; }
        public string CauseName { get; set; }
        public EquipmentClass EquipmentClass { get; set; }
        public ECauseSeverity Severity { get; set; }
        public string Note { get; set; }
        public List<MaintenanceResponse>? MaintenanceResponses { get; set; }

        public enum ECauseSeverity
        {
            Urgent,
            High,
            Normal,
            Low
        }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private Cause() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        public Cause(string causeId, string causeCode, string causeName, EquipmentClass equipmentClass, ECauseSeverity severity, string note)
        {
            CauseId = causeId;
            CauseCode = causeCode;
            CauseName = causeName;
            EquipmentClass = equipmentClass;
            Severity = severity;
            Note = note;
        }

        public void Update(string causeCode, string causeName, EquipmentClass equipmentClass, ECauseSeverity severity, string note)
        {
            CauseCode = causeCode;
            CauseName = causeName;
            EquipmentClass = equipmentClass;
            Severity = severity;
            Note = note;
        }
    }
}
