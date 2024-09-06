using static WembleyCMMS.Domain.AggregateModels.CauseAggregate.Cause;
using System.Runtime.Serialization;

namespace WembleyCMMS.Api.Application.Commands.Causes
{
    public class UpdateCauseCommand : IRequest<bool>
    {
        public string CauseId { get; set; }
        public string CauseCode { get; set; }
        public string CauseName { get; set; }
        public string EquipmentClass { get; set; }
        public ECauseSeverity Severity { get; set; }
        public string Note { get; set; }

        public UpdateCauseCommand(string causeId, string causeCode, string causeName, string equipmentClass, ECauseSeverity severity, string note)
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
