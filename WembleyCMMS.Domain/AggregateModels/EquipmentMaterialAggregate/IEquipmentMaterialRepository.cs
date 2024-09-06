namespace WembleyCMMS.Domain.AggregateModels.EquipmentMaterialAggregate
{
    public interface IEquipmentMaterialRepository : IRepository<EquipmentMaterial>
    {
        public EquipmentMaterial Add(EquipmentMaterial equipmentMaterial);
        public EquipmentMaterial Update(EquipmentMaterial equipmentMaterial);
        public Task<EquipmentMaterial?> GetById(string equipmentMaterialId);
        public Task<List<EquipmentMaterial>>? GetListByEquipmentId(string equipmentId);
        public Task Delete(string equipmentMaterialId);
    }
}
