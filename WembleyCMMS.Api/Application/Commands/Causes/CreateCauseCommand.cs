using System.Runtime.Serialization;
using static WembleyCMMS.Domain.AggregateModels.CauseAggregate.Cause;

namespace WembleyCMMS.Api.Application.Commands.Causes
{
    [DataContract]
    public class CreateCauseCommand : IRequest<bool>
    {
        public string CauseName { get; set; }
        public string EquipmentClass { get; set; }
        public ECauseSeverity Severity { get; set; }
        public string Note { get; set; }

        public CreateCauseCommand(string causeName, string equipmentClass, ECauseSeverity severity, string note)
        {
            CauseName = causeName;
            EquipmentClass = equipmentClass;
            Severity = severity;
            Note = note;
        }
    }
}
