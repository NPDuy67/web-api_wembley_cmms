namespace WembleyCMMS.Api.Application.Queries.Corrections
{
    public class CorrectionByIdQuery : PaginatedQuery, IRequest<QueryResult<CorrectionViewModel>>
    {
        public string CorrectionId { get; set; }

        public CorrectionByIdQuery(string correctionId)
        {
            CorrectionId = correctionId;
        }
    }
}
