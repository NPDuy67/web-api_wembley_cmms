using System.Runtime.Serialization;
using static WembleyCMMS.Domain.AggregateModels.CauseAggregate.Cause;

namespace WembleyCMMS.Api.Application.Commands.Causes
{
    [DataContract]
    public class UpdateCauseViewModel
    {
        public string CauseCode { get; set; }
        public string CauseName { get; set; }
        public string EquipmentClass { get; set; }
        public ECauseSeverity Severity { get; set; }
        public string Note { get; set; }

        public UpdateCauseViewModel(string causeCode, string causeName, string equipmentClass, ECauseSeverity severity, string note)
        {
            CauseCode = causeCode;
            CauseName = causeName;
            EquipmentClass = equipmentClass;
            Severity = severity;
            Note = note;
        }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private UpdateCauseViewModel() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    }
}
