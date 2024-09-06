using WembleyCMMS.Domain.AggregateModels.CauseAggregate;
using WembleyCMMS.Domain.AggregateModels.PersonAggregate;
using WembleyCMMS.Domain.AggregateModels.CorrectionAggregate;
using WembleyCMMS.Domain.AggregateModels.MaintenanceRequestAggregate;
using WembleyCMMS.Domain.AggregateModels.InspectionReportAggregate;
using WembleyCMMS.Domain.AggregateModels.MaterialInforAggregate;
using WembleyCMMS.Api.Application.Queries.Causes;
using WembleyCMMS.Api.Application.Queries.Corrections;
using WembleyCMMS.Api.Application.Queries.MaterialInfors.Materials;
using WembleyCMMS.Api.Application.Queries.Persons;
using WembleyCMMS.Api.Application.Queries.Equipments;
using WembleyCMMS.Api.Application.Queries.EquipmentClasses;

namespace WembleyCMMS.Api.Application.Queries.MaintenanceResponses
{
    public class MaintenanceResponseViewModel
    {
        public string MaintenanceResponseId { get; set; }
        public List<string> Cause { get; set; }
        public List<string> Correction { get; set; }
        public DateTime PlannedStart { get; set; }
        public DateTime? PlannedFinish { get; set; }
        public int? EstProcessTime { get; set; }
        public DateTime? ActualStartTime { get; set; }
        public DateTime? ActualFinishTime { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public PersonViewModel? ResponsiblePerson { get; set; }
        public int? Priority { get; set; }
        public string Problem { get; set; }
        public List<string>? Images { get; set; }
        public List<MaterialViewModel> Materials { get; set; }
        public string Code { get; set; }
        public string? Note { get; set; }
        public EquipmentClassViewModel EquipmentClass { get; set; }
        public EquipmentNameViewModel? Equipment { get; set; }
        public DateTime? DueDate { get; set; }
        public string? Type { get; set; }
        public List<InspectionReportWithStatusString>? InspectionReports { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private MaintenanceResponseViewModel() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        public MaintenanceResponseViewModel(string maintenanceResponseId, List<string> cause, List<string> correction, DateTime plannedStart, DateTime? plannedFinish, int? estProcessTime, DateTime? actualStartTime, DateTime? actualFinishTime, string status, DateTime createdAt, DateTime updatedAt, PersonViewModel? responsiblePerson, int? priority, string problem, List<string>? images, List<MaterialViewModel> materials, string code, string? note, EquipmentClassViewModel equipmentClass, EquipmentNameViewModel? equipment, DateTime? dueDate, string? type, List<InspectionReportWithStatusString>? inspectionReports)
        {
            MaintenanceResponseId = maintenanceResponseId;
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
            EquipmentClass = equipmentClass;
            Equipment = equipment;
            DueDate = dueDate;
            Type = type;
            InspectionReports = inspectionReports;
        }
    }
}
