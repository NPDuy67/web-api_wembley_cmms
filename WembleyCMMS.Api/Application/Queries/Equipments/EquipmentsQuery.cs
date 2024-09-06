using static WembleyCMMS.Domain.AggregateModels.MaintenanceRequestAggregate.MaintenanceRequest;
namespace WembleyCMMS.Api.Application.Queries.Equipments
{
    public class EquipmentsQuery : PaginatedQuery, IRequest<QueryResult<EquipmentViewModel>>
    {
        public string? IdStartedWith { get; set; }
        public string? EquipmentClassId { get; set; }
    }
}
