namespace WembleyCMMS.Domain.AggregateModels.EquipmentAggregate
{
    public interface IEquipmentRepository : IRepository<Equipment>
    {
        public Equipment Add(Equipment equipment);
        public Equipment Update(Equipment equipment);
        public Task<Equipment?> GetById(string equipmentId);
        public Task<Equipment?> GetByCode(string code);
        public Task<List<Equipment>?> GetByEquipmentClassId(string equipmentClassId);
        public Task<List<Equipment>?> GetAll();
        public Task Delete(string equipmentId);
    }
}
