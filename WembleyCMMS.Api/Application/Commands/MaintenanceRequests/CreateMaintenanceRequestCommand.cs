using System.Runtime.Serialization;
using static WembleyCMMS.Domain.AggregateModels.MaintenanceRequestAggregate.MaintenanceRequest;

namespace WembleyCMMS.Api.Application.Commands.MaintenanceRequests
{
    [DataContract]
    public class CreateMaintenanceRequestCommand : IRequest<bool>
    {
        public string Problem { get; set; }
        public DateTime RequestedCompletionDate { get; set; }
        public int? RequestedPriority { get; set; }
        public string Requester { get; set; }
        public string? Reviewer { get; set; }
        public EMaintenanceType Type { get; set; }
        public string EquipmentClass { get; set; }
        public string? Equipment { get; set; }
        public List<string>? Images { get; set; }
        public string? ResponsiblePerson { get; set; }
        public int? EstProcessingTime { get; set; }
        public DateTime PlannedStart { get; set; }

        public CreateMaintenanceRequestCommand(string problem, DateTime requestedCompletionDate, int? requestedPriority, string requester, string? reviewer, EMaintenanceType type, string equipmentClass, string? equipment, List<string>? images, string? responsiblePerson, int? estProcessingTime, DateTime plannedStart)
        {
            Problem = problem;
            RequestedCompletionDate = requestedCompletionDate;
            RequestedPriority = requestedPriority;
            Requester = requester;
            Reviewer = reviewer;
            Type = type;
            EquipmentClass = equipmentClass;
            Equipment = equipment;
            Images = images;
            ResponsiblePerson = responsiblePerson;
            EstProcessingTime = estProcessingTime;
            PlannedStart = plannedStart;
        }
    }
}
