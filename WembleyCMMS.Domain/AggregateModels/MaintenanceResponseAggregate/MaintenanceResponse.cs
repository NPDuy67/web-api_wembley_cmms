using WembleyCMMS.Domain.AggregateModels.CauseAggregate;
using WembleyCMMS.Domain.AggregateModels.PersonAggregate;
using static WembleyCMMS.Domain.AggregateModels.EquipmentAggregate.Equipment;
using WembleyCMMS.Domain.AggregateModels.CorrectionAggregate;
using WembleyCMMS.Domain.AggregateModels.MaintenanceRequestAggregate;
using static WembleyCMMS.Domain.AggregateModels.MaintenanceRequestAggregate.MaintenanceRequest;
using WembleyCMMS.Domain.AggregateModels.EquipmentAggregate;
using WembleyCMMS.Domain.AggregateModels.InspectionReportAggregate;
using WembleyCMMS.Domain.AggregateModels.MaterialInforAggregate;
using WembleyCMMS.Domain.AggregateModels.EquipmentClassAggregate;

namespace WembleyCMMS.Domain.AggregateModels.MaintenanceResponseAggregate
{
    public class MaintenanceResponse : Entity, IAggregateRoot
    {
        public string MaintenanceResponseId { get; set; }
        public List<Cause> Cause { get; set; }
        public List<Correction> Correction { get; set; }
        public DateTime PlannedStart { get; set; }
        public DateTime? PlannedFinish { get; set; }
        public int? EstProcessTime { get; set; }
        public DateTime? ActualStartTime { get; set; }
        public DateTime? ActualFinishTime { get; set; }
        public EMaintenanceStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Person? ResponsiblePerson { get; set; }
        public int? Priority { get; set; }
        public string Problem { get; set; }
        public string? Images { get; set; }
        public List<Material> Materials { get; set; }
        public string Code { get; set; }
        public string? Note { get; set; }
        public MaintenanceRequest Request { get; set; }
        public EquipmentClass EquipmentClass { get; set; }
        public Equipment? Equipment { get; set; }
        public DateTime? DueDate { get; set; }
        public EMaintenanceType Type { get; set; }
        public List<InspectionReport>? InspectionReports { get; set; }

        public MaintenanceResponse(string maintenanceResponseId, List<Cause> cause, List<Correction> correction, DateTime plannedStart, DateTime? plannedFinish, int? estProcessTime, DateTime? actualStartTime, DateTime? actualFinishTime, EMaintenanceStatus status, DateTime createdAt, DateTime updatedAt, Person? responsiblePerson, int? priority, string problem, string? images, List<Material> materials, string code, string? note, MaintenanceRequest request, EquipmentClass equipmentClass, Equipment? equipment, DateTime? dueDate, EMaintenanceType type)
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
            Request = request;
            EquipmentClass = equipmentClass;
            Equipment = equipment;
            DueDate = dueDate;
            Type = type;
        }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public MaintenanceResponse(string maintenanceResponseId, DateTime plannedStart, DateTime plannedFinish, int? estProcessTime, DateTime? actualStartTime, DateTime? actualFinishTime, EMaintenanceStatus status, DateTime createdAt, DateTime updatedAt, Person? responsiblePerson, int? priority, string problem, string code, string? note, EquipmentClass equipmentClass, Equipment? equipment)
        {
            MaintenanceResponseId = maintenanceResponseId;
            PlannedStart = plannedStart;
            PlannedFinish = plannedFinish;
            EstProcessTime= estProcessTime;
            ActualStartTime = actualStartTime;
            ActualFinishTime = actualFinishTime;
            Status = status;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            ResponsiblePerson = responsiblePerson;
            Priority = priority;
            Problem = problem;
            Code = code;
            Note = note;
            EquipmentClass = equipmentClass;
            Equipment = equipment;
        }

        private MaintenanceResponse() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        public void Update(List<Cause>? cause, List<Correction>? correction, DateTime? plannedStart, DateTime? plannedFinish, int? estProcessTime, DateTime? actualStartTime, DateTime? actualFinishTime, EMaintenanceStatus? status, DateTime? updatedAt, Person? responsiblePerson, int? priority, string? problem, string? images, List<Material>? materials, string? code, string? note, EquipmentClass? equipmentClass, Equipment? equipment, DateTime? dueDate, EMaintenanceType? type, List<InspectionReport>? inspectionReports)
        {
            Cause = cause ?? Cause;
            Correction = correction ?? Correction;
            PlannedStart = plannedStart ?? PlannedStart;
            PlannedFinish = plannedFinish ?? PlannedFinish;
            EstProcessTime = estProcessTime ?? EstProcessTime;
            ActualStartTime = actualStartTime ?? ActualStartTime;
            ActualFinishTime = actualFinishTime ?? ActualFinishTime;
            Status = status ?? Status;
            UpdatedAt = updatedAt ?? UpdatedAt;
            ResponsiblePerson = responsiblePerson ?? ResponsiblePerson;
            Priority = priority ?? Priority;
            Problem = problem ?? Problem;
            Images = images ?? Images;
            Materials = materials ?? Materials;
            Code = code ?? Code;
            Note = note ?? Note;
            EquipmentClass = equipmentClass ?? EquipmentClass;
            Equipment = equipment ?? Equipment;
            DueDate = dueDate ?? DueDate;
            Type = type ?? Type;
            InspectionReports = inspectionReports ?? InspectionReports;
        }

        public enum EMaintenanceObject
        {
            equipment,
            mold
        }
    }
}

