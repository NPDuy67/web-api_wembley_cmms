using static WembleyCMMS.Domain.AggregateModels.MaintenanceRequestAggregate.MaintenanceRequest;

namespace WembleyCMMS.Api.Application.Commands.MaintenanceRequests.MaintenanceRequestStandards
{
    public class UpdateMaintenanceRequestStandardCommand : IRequest<bool>
    {
        public string EquipmentClass { get; set; }
        public EMaintenanceRequestStatus Status { get; set; }

        public UpdateMaintenanceRequestStandardCommand(string equipmentClass, EMaintenanceRequestStatus status)
        {
            EquipmentClass = equipmentClass;
            Status = status;
        }
    }
}
