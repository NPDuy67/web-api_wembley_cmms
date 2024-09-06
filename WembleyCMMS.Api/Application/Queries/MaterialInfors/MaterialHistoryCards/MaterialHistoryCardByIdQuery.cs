namespace WembleyCMMS.Api.Application.Queries.MaterialInfors.MaterialHistoryCards
{
    public class MaterialHistoryCardByIdQuery : IRequest<QueryResult<MaterialHistoryCardViewModel>>
    {
        public string MaterialInforId { get; set; }
        public string MaterialHistoryCardId { get; set; }

        public MaterialHistoryCardByIdQuery(string materialInforId, string materialHistoryCardId)
        {
            MaterialInforId = materialInforId;
            MaterialHistoryCardId = materialHistoryCardId;
        }
    }
}
