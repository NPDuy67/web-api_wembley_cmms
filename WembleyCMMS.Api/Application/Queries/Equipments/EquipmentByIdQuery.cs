namespace WembleyCMMS.Api.Application.Queries.Equipments
{
    public class EquipmentByIdQuery : IRequest<QueryResult<EquipmentViewModel>>
    {
        public string EquipmentId { get; set; }

        public EquipmentByIdQuery(string equipmentId)
        {
            EquipmentId = equipmentId;
        }
    }
}
