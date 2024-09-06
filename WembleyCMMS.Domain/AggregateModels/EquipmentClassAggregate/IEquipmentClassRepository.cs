namespace WembleyCMMS.Domain.AggregateModels.EquipmentClassAggregate
{
    public interface IEquipmentClassRepository : IRepository<EquipmentClass>
    {
        public EquipmentClass Add(EquipmentClass equipmentClass);
        public EquipmentClass Update(EquipmentClass equipmentClass);
        public Task<EquipmentClass?> GetById(string equipmentClassId);
        public Task<List<EquipmentClass>?> GetAll();
        public Task Delete(string equipmentClassId);
    }
}
