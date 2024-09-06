using System.Runtime.Serialization;
using static WembleyCMMS.Domain.AggregateModels.EquipmentAggregate.Equipment;
using static WembleyCMMS.Domain.AggregateModels.MaintenanceRequestAggregate.MaintenanceRequest;

namespace WembleyCMMS.Api.Application.Commands.MaintenanceResponses
{
    [DataContract]
    public class CreateMaintenanceResponseCommand : IRequest<bool>
    {
        public DateTime PlannedStart { get; set; }
        public DateTime PlannedFinish { get; set; }
        public int? EstProcessTime { get; set; }
        public DateTime? ActualStartTime { get; set; }
        public DateTime? ActualFinishTime { get; set; }
        public EMaintenanceStatus Status { get; set; }
        public string? ResponsiblePerson { get; set; }
        public int? Priority { get; set; }
        public string Problem { get; set; }
        public string? Note { get; set; }
        public string Request { get; set; }
        public string EquipmentClass { get; set; }
        public string? Equipment { get; set; }
        public DateTime? DueDate { get; set; }
        public EMaintenanceType Type { get; set; }

        public CreateMaintenanceResponseCommand(DateTime plannedStart, DateTime plannedFinish, int? estProcessTime, DateTime? actualStartTime, DateTime? actualFinishTime, EMaintenanceStatus status, string? responsiblePerson, int? priority, string problem, string? note, string request, string equipmentClass, string? equipment, DateTime? dueDate, EMaintenanceType type)
        {
            PlannedStart = plannedStart;
            PlannedFinish = plannedFinish;
            EstProcessTime = estProcessTime;
            ActualStartTime = actualStartTime;
            ActualFinishTime = actualFinishTime;
            Status = status;
            ResponsiblePerson = responsiblePerson;
            Priority = priority;
            Problem = problem;
            Note = note;
            Request = request;
            EquipmentClass = equipmentClass;
            Equipment = equipment;
            DueDate = dueDate;
            Type = type;
        }
    }
}
