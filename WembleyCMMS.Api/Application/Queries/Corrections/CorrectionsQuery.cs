namespace WembleyCMMS.Api.Application.Queries.Corrections
{
    public class CorrectionsQuery : PaginatedQuery, IRequest<QueryResult<CorrectionViewModel>>
    {
        public string? IdStartedWith { get; set; }
    }
}
