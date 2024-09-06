namespace WembleyCMMS.Api.Application.Queries.Causes
{
    public class CausesQuery : PaginatedQuery, IRequest<QueryResult<CauseViewModel>>
    {
        public string? IdStartedWith { get; set; }
    }
}
