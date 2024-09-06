using static WembleyCMMS.Domain.AggregateModels.EquipmentAggregate.Equipment;
using static WembleyCMMS.Domain.AggregateModels.MaintenanceRequestAggregate.MaintenanceRequest;

namespace WembleyCMMS.Api.Application.Queries.MaintenanceResponses
{
    public class MaintenanceResponsesQuery : PaginatedQuery, IRequest<QueryResult<MaintenanceResponseViewModel>>
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public EMaintenanceStatus? Status { get; set; }
        public EMaintenanceType? Type { get; set; }

        public MaintenanceResponsesQuery() { }

        public MaintenanceResponsesQuery(DateTime? startDate, DateTime? endDate, EMaintenanceStatus? status, EMaintenanceType? type)
        {
            StartDate = startDate;
            EndDate = endDate;
            Status = status;
            Type = type;
        }
    }
}
