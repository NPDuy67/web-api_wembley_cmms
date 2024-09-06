using static WembleyCMMS.Domain.AggregateModels.MaintenanceRequestAggregate.MaintenanceRequest;

namespace WembleyCMMS.Api.Application.Queries.MaintenanceRequests
{
    public class MaintenanceRequestsQuery : PaginatedQuery, IRequest<QueryResult<MaintenanceRequestViewModel>>
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public EMaintenanceRequestStatus? Status { get; set; }
        public EMaintenanceType? Type { get; set; }
        public string? EquipmentClassId { get; set; }

        public MaintenanceRequestsQuery() { }

        public MaintenanceRequestsQuery(DateTime? startDate, DateTime? endDate, EMaintenanceRequestStatus? status, EMaintenanceType? type, string? equipmentClassId)
        {
            StartDate = startDate;
            EndDate = endDate;
            Status = status;
            Type = type;
            EquipmentClassId = equipmentClassId;
        }
    }
}
