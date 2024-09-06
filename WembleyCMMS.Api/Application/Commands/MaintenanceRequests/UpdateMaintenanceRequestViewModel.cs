using System.Runtime.Serialization;
using static WembleyCMMS.Domain.AggregateModels.MaintenanceRequestAggregate.MaintenanceRequest;

namespace WembleyCMMS.Api.Application.Commands.MaintenanceRequests
{
    [DataContract]
    public class UpdateMaintenanceRequestViewModel
    {
        public string? Code { get; set; }
        public string? Problem { get; set; }
        public DateTime? RequestedCompletionDate { get; set; }
        public int? RequestedPriority { get; set; }
        public string? Requester { get; set; }
        public EMaintenanceRequestStatus? Status { get; set; }
        public string? Reviewer { get; set; }
        public DateTime? SubmissionDate { get; set; }
        public EMaintenanceType? Type { get; set; }
        public string? EquipmentClass { get; set; }
        public string? Equipment { get; set; }
        public List<string>? Images { get; set; }
        public string? ResponsiblePerson { get; set; }
        public int? EstProcessingTime { get; set; }
        public DateTime? PlannedStart { get; set; }

        private UpdateMaintenanceRequestViewModel() { }

        public UpdateMaintenanceRequestViewModel(string? code, string? problem, DateTime? requestedCompletionDate, int? requestedPriority, string? requester, EMaintenanceRequestStatus? status, string? reviewer, DateTime? submissionDate, EMaintenanceType? type, string? equipmentClass, string? equipment, List<string>? images, string? responsiblePerson, int? estProcessingTime, DateTime? plannedStart)
        {
            Code = code;
            Problem = problem;
            RequestedCompletionDate = requestedCompletionDate;
            RequestedPriority = requestedPriority;
            Requester = requester;
            Status = status;
            Reviewer = reviewer;
            SubmissionDate = submissionDate;
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
