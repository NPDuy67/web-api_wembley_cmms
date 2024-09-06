namespace WembleyCMMS.Api.Application.Queries.MaintenanceResponses
{
    public class MaintenanceResponseByIdQuery : PaginatedQuery, IRequest<QueryResult<MaintenanceResponseViewModel>>
    {
        public string MaintenanceResponseId { get; set; }
        public MaintenanceResponseByIdQuery(string maintenanceResponseId)
        {
            MaintenanceResponseId = maintenanceResponseId;
        }
    }
}
