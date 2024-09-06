namespace WembleyCMMS.Api.Application.Queries.MaterialInfors.Materials
{
    public class MaterialBySkuQuery : IRequest<QueryResult<MaterialViewModel>>
    {
        public string MaterialInforId { get; set; }
        public string Sku { get; set; }

        public MaterialBySkuQuery(string materialInforId, string sku)
        {
            MaterialInforId = materialInforId;
            Sku = sku;
        }
    }
}
