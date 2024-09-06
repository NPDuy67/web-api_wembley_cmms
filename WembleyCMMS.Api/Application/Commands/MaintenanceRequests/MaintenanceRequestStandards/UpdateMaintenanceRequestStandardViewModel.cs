using System.Runtime.Serialization;
using static WembleyCMMS.Domain.AggregateModels.MaintenanceRequestAggregate.MaintenanceRequest;

namespace WembleyCMMS.Api.Application.Commands.MaintenanceRequests.MaintenanceRequestStandards
{
    [DataContract]
    public class UpdateMaintenanceRequestStandardViewModel
    {
        public EMaintenanceRequestStatus Status { get; set; }

        public UpdateMaintenanceRequestStandardViewModel(EMaintenanceRequestStatus status)
        {
            Status = status;
        }
    }
}
