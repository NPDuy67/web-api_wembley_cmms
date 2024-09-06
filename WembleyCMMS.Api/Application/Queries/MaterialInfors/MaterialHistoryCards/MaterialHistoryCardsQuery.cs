namespace WembleyCMMS.Api.Application.Queries.MaterialInfors.MaterialHistoryCards
{
    public class MaterialHistoryCardsQuery : PaginatedQuery, IRequest<QueryResult<MaterialHistoryCardViewModel>>
    {
        public string MaterialInforId { get; set; }

        public MaterialHistoryCardsQuery(string materialInforId)
        {
            MaterialInforId = materialInforId;
        }
    }
}
