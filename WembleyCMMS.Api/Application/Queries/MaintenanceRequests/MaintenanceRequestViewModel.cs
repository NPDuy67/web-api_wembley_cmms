using WembleyCMMS.Api.Application.Queries.EquipmentClasses;
using WembleyCMMS.Api.Application.Queries.Equipments;
using WembleyCMMS.Api.Application.Queries.Persons;

namespace WembleyCMMS.Api.Application.Queries.MaintenanceRequests
{
    public class MaintenanceRequestViewModel
    {
        public string MaintenanceRequestId { get; set; }
        public string Code { get; set; }
        public string Problem { get; set; }
        public DateTime RequestedCompletionDate { get; set; }
        public int RequestedPriority { get; set; }
        public PersonViewModel? Requester { get; set; }
        public string Status { get; set; } //Enum
        public PersonViewModel? Reviewer { get; set; }
        public DateTime? SubmissionDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string Type { get; set; } //Enum
        public string EquipmentClass { get; set; }
        public string? Equipment { get; set; }
        public List<string>? Images { get; set; }
        public PersonViewModel? ResponsiblePerson { get; set; }
        public int? EstProcessingTime { get; set; }
        public DateTime PlannedStart { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private MaintenanceRequestViewModel() { }


        public MaintenanceRequestViewModel(string maintenanceRequestId, string code, string problem, DateTime requestedCompletionDate, int requestedPriority, PersonViewModel? requester, string status, PersonViewModel? reviewer, DateTime? submissionDate, DateTime createdAt, DateTime updatedAt, string type, string equipmentClass, string? equipment, List<string>? images, PersonViewModel? responsiblePerson, int? estProcessingTime, DateTime plannedStart)
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
    }
}
