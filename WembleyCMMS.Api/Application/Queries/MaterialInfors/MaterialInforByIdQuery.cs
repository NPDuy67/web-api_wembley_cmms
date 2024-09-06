namespace WembleyCMMS.Api.Application.Queries.MaterialInfors
{
    public class MaterialInforByIdQuery : IRequest<QueryResult<MaterialInforViewModel>>
    {
        public string? MaterialInforId { get; set; }

        public MaterialInforByIdQuery(string? equipmentId)
        {
            MaterialInforId = equipmentId;
        }
    }
}
