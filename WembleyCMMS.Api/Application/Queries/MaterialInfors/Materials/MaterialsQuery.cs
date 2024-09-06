using static WembleyCMMS.Domain.AggregateModels.MaterialInforAggregate.Material;

namespace WembleyCMMS.Api.Application.Queries.MaterialInfors.Materials
{
    public class MaterialsQuery : PaginatedQuery, IRequest<QueryResult<MaterialViewModel>>
    {
        public string MaterialInforId { get; set; }
        public EMaterialStatus? Status { get; set; }

        public MaterialsQuery(string materialInforId, EMaterialStatus? status)
        {
            MaterialInforId = materialInforId;
            Status = status;
        }
    }
}
