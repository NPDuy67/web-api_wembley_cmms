namespace WembleyCMMS.Api.Application.Queries.EquipmentMaterials
{
    public class EquipmentMaterialByEquipmentIdQuery : PaginatedQuery, IRequest<QueryResult<EquipmentMaterialViewModel>>
    {
        public string EquipmentId { get; set; }

        public EquipmentMaterialByEquipmentIdQuery(string equipmentId)
        {
            EquipmentId = equipmentId;
        }
    }
}
