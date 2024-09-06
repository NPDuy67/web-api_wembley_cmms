using WembleyCMMS.Domain.AggregateModels.CauseAggregate;
using WembleyCMMS.Domain.AggregateModels.PersonAggregate;
using WembleyCMMS.Domain.AggregateModels.CorrectionAggregate;
using WembleyCMMS.Domain.AggregateModels.MaintenanceRequestAggregate;
using WembleyCMMS.Domain.AggregateModels.InspectionReportAggregate;
using WembleyCMMS.Domain.AggregateModels.MaterialInforAggregate;
using WembleyCMMS.Domain.AggregateModels.EquipmentClassAggregate;

namespace WembleyCMMS.Api.Application.Queries.MaintenanceResponses
{
    public class MaintenanceResponseGetViewModel
    {
        public string MaintenanceResponseId { get; set; }
        public List<Cause> Cause { get; set; }
        public List<Correction> Correction { get; set; }
        public DateTime PlannedStart { get; set; }
        public DateTime? PlannedFinish { get; set; }
        public int? EstProcessTime { get; set; }
        public DateTime? ActualStartTime { get; set; }
        public DateTime? ActualFinishTime { get; set; }
        public string Status { get; set; } 
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Person? ResponsiblePerson { get; set; }
        public int? Priority { get; set; }
        public string Problem { get; set; }
        public List<string>? Images { get; set; }
        public List<Material> Materials { get; set; }
        public string Code { get; set; }
        public string? Note { get; set; }
        public MaintenanceRequest Request { get; set; }
        public EquipmentClass EquipmentClass { get; set; }
        public Equipment? Equipment { get; set; }
        public DateTime? DueDate { get; set; }
        public string? Type { get; set; }
        public List<InspectionReportWithStatusString>? InspectionReports { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private MaintenanceResponseGetViewModel() { }

        public MaintenanceResponseGetViewModel(string maintenanceResponseId)
        {
            MaintenanceResponseId = maintenanceResponseId;
        }

        public MaintenanceResponseGetViewModel(string maintenanceResponseId, List<Cause> cause, List<Correction> correction, DateTime plannedStart, DateTime? plannedFinish, int? estProcessTime, DateTime? actualStartTime, DateTime? actualFinishTime, string status, DateTime createdAt, DateTime updatedAt, Person? responsiblePerson, int? priority, string problem, List<string>? images, List<Material> materials, string code, string? note, MaintenanceRequest request, EquipmentClass equipmentClass, Equipment? equipment, DateTime? dueDate, string? type, List<InspectionReportWithStatusString>? inspectionReports) : this(maintenanceResponseId)
        {
            Cause = cause;
            Correction = correction;
            PlannedStart = plannedStart;
            PlannedFinish = plannedFinish;
            EstProcessTime = estProcessTime;
            ActualStartTime = actualStartTime;
            ActualFinishTime = actualFinishTime;
            Status = status;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            ResponsiblePerson = responsiblePerson;
            Priority = priority;
            Problem = problem;
            Images = images;
            Materials = materials;
            Code = code;
            Note = note;
            Request = request;
            EquipmentClass = equipmentClass;
            Equipment = equipment;
            DueDate = dueDate;
            Type = type;
            InspectionReports = inspectionReports;
        }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.


    }
}
