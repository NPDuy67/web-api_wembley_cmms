namespace WembleyCMMS.Api.Application.Queries.MaterialInfors.Materials
{
    public class MaterialByIdQuery : IRequest<QueryResult<MaterialViewModel>>
    {
        public string MaterialInforId { get; set; }
        public string MaterialId { get; set; }

        public MaterialByIdQuery(string materialInforId, string materialId)
        {
            MaterialInforId = materialInforId;
            MaterialId = materialId;
        }
    }
}
