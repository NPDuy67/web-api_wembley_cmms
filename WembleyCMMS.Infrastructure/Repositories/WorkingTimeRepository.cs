using Microsoft.IdentityModel.Tokens;
using WembleyCMMS.Domain.AggregateModels.WorkingTimeAggregate;

namespace WembleyCMMS.Infrastructure.Repositories
{
    public class WorkingTimeRepository : BaseRepository, IWorkingTimeRepository
    {
        public WorkingTimeRepository(ApplicationDbContext context) : base(context)
        {
        }

        public WorkingTime Add(WorkingTime workingTime)
        {
            if (workingTime.IsTransient())
            {
                return _context.WorkingTimes
                    .Add(workingTime)
                    .Entity;
            }
            else
            {
                return workingTime;
            }
        }

        public WorkingTime Update(WorkingTime workingTime)
        {
            return _context.WorkingTimes
                    .Update(workingTime)
                    .Entity;
        }

        public async Task<WorkingTime?> GetById(string workingTimeId)
        {
            return await _context.WorkingTimes
                .FirstOrDefaultAsync(x => x.WorkingTimeId == workingTimeId);
        }

        public async Task<List<WorkingTime>> GetByEquipmentId(string equipmentId)
        {
            return await _context.WorkingTimes
                .Include(x => x.Equipment)
                .Include(x => x.ResponsiblePerson)
                .Where(x => x.Equipment.EquipmentId  == equipmentId)
                .ToListAsync();
        }

        public async Task<WorkingTime?> GetByActualStartTime(DateTime actualStartTime)
        {
            return await _context.WorkingTimes
                .Include(x => x.Equipment)
                .Include(x => x.ResponsiblePerson)
                .FirstOrDefaultAsync(x => x.From == actualStartTime);
        }

        public async Task Delete(string workingTimeId)
        {
            var workingTime = await _context.WorkingTimes
                .FirstOrDefaultAsync(x => x.WorkingTimeId == workingTimeId);

            if (workingTime is not null)
            {
                _context.WorkingTimes.Remove(workingTime);
            }
        }
    }
}
