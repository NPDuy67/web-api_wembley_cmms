namespace WembleyCMMS.Api.Application.Queries.MaintenanceRequests
{
    public class MaintenanceRequestByIdQuery : PaginatedQuery, IRequest<QueryResult<MaintenanceRequestViewModel>>
    {
        public string MaintenanceRequestId { get; set; }

        public MaintenanceRequestByIdQuery(string maintenanceRequestId)
        {
            MaintenanceRequestId = maintenanceRequestId;
        }
    }
}
