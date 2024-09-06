using WembleyCMMS.Domain.AggregateModels.MaintenanceRequestAggregate;

namespace WembleyCMMS.Infrastructure.Repositories
{
    public class MaintenanceRequestRepository : BaseRepository, IMaintenanceRequestRepository
    {
        public MaintenanceRequestRepository(ApplicationDbContext context) : base(context)
        {
        }

        public MaintenanceRequest Add(MaintenanceRequest maintenanceRequest)
        {
            if (maintenanceRequest.IsTransient())
            {
                return _context.MaintenanceRequests
                    .Add(maintenanceRequest)
                    .Entity;
            }
            else
            {
                return maintenanceRequest;
            }
        }

        public MaintenanceRequest Update(MaintenanceRequest maintenanceRequest)
        {
            return _context.MaintenanceRequests
                    .Update(maintenanceRequest)
                    .Entity;
        }

        public async Task<MaintenanceRequest?> GetById(string maintenanceRequestId)
        {
            return await _context.MaintenanceRequests
                .Include(x => x.EquipmentClass)
                .Include(x => x.Equipment)
                .Include(x => x.Requester)
                .Include(x => x.Reviewer)
                .Include(x => x.ResponsiblePerson)
                .FirstOrDefaultAsync(x => x.MaintenanceRequestId == maintenanceRequestId);
        }

        public async Task<List<MaintenanceRequest>> GetAll()
        {
            return await _context.MaintenanceRequests
                .Include(x => x.EquipmentClass)
                .ToListAsync();
        }

        public async Task Delete(string maintenanceRequestId)
        {
            var maintenanceRequest = await _context.MaintenanceRequests
                .FirstOrDefaultAsync(x => x.MaintenanceRequestId == maintenanceRequestId);

            if (maintenanceRequest is not null)
            {
                _context.MaintenanceRequests.Remove(maintenanceRequest);
            }
        }
    }
}
