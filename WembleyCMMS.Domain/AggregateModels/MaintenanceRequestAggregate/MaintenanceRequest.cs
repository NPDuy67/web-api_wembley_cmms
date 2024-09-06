using WembleyCMMS.Domain.AggregateModels.PersonAggregate;
using WembleyCMMS.Domain.AggregateModels.EquipmentAggregate;
using WembleyCMMS.Domain.AggregateModels.EquipmentClassAggregate;

namespace WembleyCMMS.Domain.AggregateModels.MaintenanceRequestAggregate
{
    public class MaintenanceRequest : Entity, IAggregateRoot
    {
        public string MaintenanceRequestId { get; set; }
        public string Code { get; set; }
        public string Problem { get; set; }
        public DateTime RequestedCompletionDate { get; set; }
        public int? RequestedPriority { get; set; }
        public Person? Requester { get; set; }
        public EMaintenanceRequestStatus Status { get; set; }
        public Person? Reviewer { get; set; }
        public DateTime? SubmissionDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public EMaintenanceType Type { get; set; }
        public EquipmentClass EquipmentClass { get; set; }
        public Equipment? Equipment { get; set; }
        public string? Images { get; set; }
        public Person? ResponsiblePerson { get; set; }
        public int? EstProcessingTime { get; set; }
        public DateTime PlannedStart { get; set; }


        public enum EMaintenanceRequestStatus
        {
            Submitted,
            Rejected,
            Approved
        }
        public enum EMaintenanceType
        {
            Reactive,
            Preventive,
            PreventiveInspection,
            Predictive
        }

        public MaintenanceRequest(string maintenanceRequestId, string code, string problem, DateTime requestedCompletionDate, int? requestedPriority, Person? requester, EMaintenanceRequestStatus status, Person? reviewer, DateTime? submissionDate, DateTime createdAt, DateTime updatedAt, EMaintenanceType type, EquipmentClass equipmentClass, Equipment? equipment, string? images, Person? responsiblePerson, int? estProcessingTime, DateTime plannedStart)
        {
            MaintenanceRequestId = maintenanceRequestId;
            Code = code;
            Problem = problem;
            RequestedCompletionDate = requestedCompletionDate;
            RequestedPriority = requestedPriority;
            Requester = requester;
            Status = status;
            Reviewer = reviewer;
            SubmissionDate = submissionDate;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            Type = type;
            EquipmentClass = equipmentClass;
            Equipment = equipment;
            Images = images;
            ResponsiblePerson = responsiblePerson;
            EstProcessingTime = estProcessingTime;
            PlannedStart = plannedStart;
        }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private MaintenanceRequest() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        public void Update(string? code, string? problem, DateTime? requestedCompletionDate, int? requestedPriority, Person? requester, EMaintenanceRequestStatus? status, Person? reviewer, DateTime? submissionDate, DateTime updatedAt, EMaintenanceType? type, EquipmentClass? equipmentClass, Equipment? equipment, string? images, Person? responsiblePerson, int? estProcessingTime, DateTime? plannedStart)
        {
            Code = code ?? Code;
            Problem = problem ?? Problem;
            RequestedCompletionDate = requestedCompletionDate ?? RequestedCompletionDate;
            RequestedPriority = requestedPriority ?? RequestedPriority;
            Requester = requester ?? Requester;
            Status = status ?? Status;
            Reviewer = reviewer ?? Reviewer;
            SubmissionDate = submissionDate ?? SubmissionDate;
            UpdatedAt = updatedAt;
            Type = type ?? Type;
            EquipmentClass = equipmentClass ?? EquipmentClass;
            Equipment = equipment ?? Equipment;
            Images = images ?? Images;
            ResponsiblePerson = responsiblePerson ?? ResponsiblePerson;
            EstProcessingTime = estProcessingTime ?? EstProcessingTime;
            PlannedStart = plannedStart ?? PlannedStart;
        }

        public void UpdateStatus(EMaintenanceRequestStatus status)
        {
            Status = status;
        }
    }
}
