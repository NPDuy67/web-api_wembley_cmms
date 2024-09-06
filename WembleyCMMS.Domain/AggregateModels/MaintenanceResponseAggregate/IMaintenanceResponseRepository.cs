namespace WembleyCMMS.Domain.AggregateModels.MaintenanceResponseAggregate
{
    public interface IMaintenanceResponseRepository : IRepository<MaintenanceResponse>
    {
        public MaintenanceResponse Add(MaintenanceResponse maintenanceResponse);
        public MaintenanceResponse Update(MaintenanceResponse maintenanceResponse);
        public Task<MaintenanceResponse?> GetById(string maintenanceResponseId);
        public Task<List<MaintenanceResponse>> GetListByEquipmentId(string equipmentId);
        public Task<List<MaintenanceResponse>> GetAll();
        public Task Delete(string maintenanceResponseId);
    }
}
