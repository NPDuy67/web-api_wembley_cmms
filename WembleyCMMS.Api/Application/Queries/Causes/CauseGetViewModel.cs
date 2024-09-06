using WembleyCMMS.Domain.AggregateModels.EquipmentClassAggregate;

namespace WembleyCMMS.Api.Application.Queries.Causes
{
    public class CauseGetViewModel
    {
        public string CauseId { get; set; }
        public string CauseCode { get; set; }
        public string CauseName { get; set; }
        public EquipmentClass EquipmentClass { get; set; }
        public string Severity { get; set; }
        public string Note { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private CauseGetViewModel() { }

        public CauseGetViewModel(string causeId)
        {
            CauseId = causeId;
        }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        public CauseGetViewModel(string causeId, string causeCode, string causeName, EquipmentClass equipmentClass, string severity, string note)
        {
            CauseId = causeId;
            CauseCode = causeCode;
            CauseName = causeName;
            EquipmentClass = equipmentClass;
            Severity = severity;
            Note = note;
        }
    }
}
