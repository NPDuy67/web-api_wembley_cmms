namespace WembleyCMMS.Api.Application.Queries.PerformanceIndexs
{
    public class PerformanceIndexsQuery : PaginatedQuery, IRequest<QueryResult<PerformanceIndexViewModel>>
    {
        public string? IdStartedWith { get; set; }
    }
}
