using WembleyCMMS.Domain.AggregateModels.EquipmentClassAggregate;
using WembleyCMMS.Domain.AggregateModels.PersonAggregate;

namespace WembleyCMMS.Api.Application.Queries.MaintenanceRequests
{
    public class MaintenanceRequestGetViewModel
    {
        public string MaintenanceRequestId { get; set; }
        public string Code { get; set; }
        public string Problem { get; set; }
        public DateTime RequestedCompletionDate { get; set; }
        public int? RequestedPriority { get; set; }
        public Person? Requester { get; set; }
        public string Status { get; set; } //Enum
        public Person? Reviewer { get; set; }
        public DateTime? SubmissionDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string Type { get; set; } //Enum
        public EquipmentClass EquipmentClass { get; set; }
        public Equipment? Equipment { get; set; }
        public List<string>? Images { get; set; }
        public Person? ResponsiblePerson { get; set; }
        public int? EstProcessingTime { get; set; }
        public DateTime PlannedStart { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private MaintenanceRequestGetViewModel() { }

        public MaintenanceRequestGetViewModel(string maintenanceRequestId)
        {
            MaintenanceRequestId = maintenanceRequestId;
        }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        public MaintenanceRequestGetViewModel(string maintenanceRequestId, string code, string problem, DateTime requestedCompletionDate, int requestedPriority, Person? requester, string status, Person? reviewer, DateTime? submissionDate, DateTime createdAt, DateTime updatedAt, string type, EquipmentClass equipmentClass, Equipment? equipment, List<string>? images, Person? responsiblePerson, int? estProcessingTime, DateTime plannedStart) : this(maintenanceRequestId)
        {
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
    }
}
