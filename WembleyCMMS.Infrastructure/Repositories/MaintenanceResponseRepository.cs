using WembleyCMMS.Domain.AggregateModels.MaintenanceResponseAggregate;
using static WembleyCMMS.Domain.AggregateModels.EquipmentAggregate.Equipment;

namespace WembleyCMMS.Infrastructure.Repositories
{
    public class MaintenanceResponseRepository : BaseRepository, IMaintenanceResponseRepository
    {
        public MaintenanceResponseRepository(ApplicationDbContext context) : base(context)
        {
        }

        public MaintenanceResponse Add(MaintenanceResponse maintenanceResponse)
        {
            if (maintenanceResponse.IsTransient())
            {
                return _context.MaintenanceResponses
                    .Add(maintenanceResponse)
                    .Entity;
            }
            else
            {
                return maintenanceResponse;
            }
        }

        public MaintenanceResponse Update(MaintenanceResponse maintenanceResponse)
        {
            return _context.MaintenanceResponses
                    .Update(maintenanceResponse)
                    .Entity;
        }

        public async Task<MaintenanceResponse?> GetById(string maintenanceResponseId)
        {
            return await _context.MaintenanceResponses
                .Include(x => x.Cause)
                .Include(x => x.Correction)
                .Include(x => x.Materials)
                .ThenInclude(x => x.MaterialInfor)
                .ThenInclude(x => x.MaterialHistoryCards)
                .Include(x => x.Materials)
                .ThenInclude(x => x.MaterialInfor)
                .ThenInclude(x => x.MaterialRequests)

                .Include(x => x.EquipmentClass)
                .Include(x => x.Equipment)
                .ThenInclude(x => x.Materials)
                .ThenInclude(x => x.MaterialInfor)
                .Include(x => x.InspectionReports)
                .Include(x => x.ResponsiblePerson)
                .FirstOrDefaultAsync(x => x.MaintenanceResponseId == maintenanceResponseId);
        }

        public async Task<List<MaintenanceResponse>> GetListByEquipmentId(string equipmentId)
        {
             return await _context.MaintenanceResponses
                .Include(x => x.Cause)
                .ThenInclude(x => x.EquipmentClass)
                .Include(x => x.Cause)
                .ThenInclude(x => x.MaintenanceResponses)
                .Include(x => x.Correction)
                .ThenInclude(x => x.MaintenanceResponses)
                .Include(x => x.Materials)
                .ThenInclude(x => x.MaterialInfor)
                .Include(x => x.ResponsiblePerson)
                .Include(x => x.InspectionReports)
                .Include(x => x.EquipmentClass)
                .Include(x => x.Equipment)
                .Where(x => x.Equipment.EquipmentId == equipmentId)
                .ToListAsync();
        }

        public async Task<List<MaintenanceResponse>> GetAll()
        {
            return await _context.MaintenanceResponses
                .Include(x => x.Cause)
                .Include(x => x.Correction)
                .Include(x => x.Materials)
                .ThenInclude(x => x.MaterialInfor)

                .Include(x => x.Equipment)
                .ThenInclude(x => x.Materials)
                .ThenInclude(x => x.MaterialInfor)
                .Include(x => x.EquipmentClass)
                .Include(x => x.InspectionReports)
                .ToListAsync();
        }

        public async Task Delete(string maintenanceResponseId)
        {
            var maintenanceResponse = await _context.MaintenanceResponses
                .FirstOrDefaultAsync(x => x.MaintenanceResponseId == maintenanceResponseId);

            if (maintenanceResponse is not null)
            {
                if (maintenanceResponse.Status != EMaintenanceStatus.Assigned)
                {
                    throw new InvalidOperationException("Cannot delete maintenance response that is not in Assigned status.");
                }
                _context.MaintenanceResponses.Remove(maintenanceResponse);
            }
        }
    }
}
