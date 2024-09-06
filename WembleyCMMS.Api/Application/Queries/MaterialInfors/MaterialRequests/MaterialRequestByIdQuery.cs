namespace WembleyCMMS.Api.Application.Queries.MaterialInfors.MaterialRequests
{
    public class MaterialRequestByIdQuery : IRequest<QueryResult<MaterialRequestViewModel>>
    {
        public string MaterialInforId { get; set; }
        public string MaterialRequestId { get; set; }

        public MaterialRequestByIdQuery(string materialInforId, string materialRequestId)
        {
            MaterialInforId = materialInforId;
            MaterialRequestId = materialRequestId;
        }
    }
}
