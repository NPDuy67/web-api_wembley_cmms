using WembleyCMMS.Api.Application.Queries.EquipmentMaterials;

namespace WembleyCMMS.Api.Application.Queries.EquipmentEquipmentMaterials
{
    public class EquipmentMaterialsQuery : PaginatedQuery, IRequest<QueryResult<EquipmentMaterialViewModel>>
    {
        public string? IdStartedWith { get; set; }
    }
}
