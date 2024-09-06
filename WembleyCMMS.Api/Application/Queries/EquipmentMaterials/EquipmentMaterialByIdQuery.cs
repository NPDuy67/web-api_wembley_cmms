using WembleyCMMS.Api.Application.Queries.EquipmentMaterials;

namespace WembleyCMMS.Api.Application.Queries.EquipmentEquipmentMaterials
{
    public class EquipmentMaterialByIdQuery : PaginatedQuery, IRequest<QueryResult<EquipmentMaterialViewModel>>
    {
        public string EquipmentMaterialId { get; set; }

        public EquipmentMaterialByIdQuery(string equipmentMaterialId)
        {
            EquipmentMaterialId = equipmentMaterialId;
        }
    }
}
