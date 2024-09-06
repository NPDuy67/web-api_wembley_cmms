namespace WembleyCMMS.Domain.AggregateModels.WorkingTimeAggregate
{
    public interface IWorkingTimeRepository : IRepository<WorkingTime>
    {
        public WorkingTime Add(WorkingTime workingTime);
        public WorkingTime Update(WorkingTime workingTime);
        public Task<WorkingTime?> GetById(string workingTimeId);
        public Task Delete(string workingTimeId);
        public Task<List<WorkingTime>> GetByEquipmentId(string equipmentId);
        public Task<WorkingTime?> GetByActualStartTime(DateTime actualStartTime);
    }
}
