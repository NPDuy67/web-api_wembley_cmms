using WembleyCMMS.Domain.AggregateModels.MaintenanceResponseAggregate;

namespace WembleyCMMS.Domain.AggregateModels.MaintenanceRequestAggregate
{
    public interface IMaintenanceRequestRepository : IRepository<MaintenanceRequest>
    {
        public MaintenanceRequest Add(MaintenanceRequest maintenanceRequest);
        public MaintenanceRequest Update(MaintenanceRequest maintenanceRequest);
        public Task<MaintenanceRequest?> GetById(string maintenanceRequestId);
        public Task<List<MaintenanceRequest>> GetAll();
        public Task Delete(string maintenanceRequestId);
    }
}
