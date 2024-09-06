using WembleyCMMS.Domain.AggregateModels.CauseAggregate;

namespace WembleyCMMS.Infrastructure.Repositories
{
    public class CauseRepository : BaseRepository, ICauseRepository
    {
        public CauseRepository(ApplicationDbContext context) : base(context)
        {
        }

        public Cause Add(Cause cause)
        {
            if (cause.IsTransient())
            {
                return _context.Causes
                    .Add(cause)
                    .Entity;
            }
            else
            {
                return cause;
            }
        }

        public Cause Update(Cause cause)
        {
            return _context.Causes
                    .Update(cause)
                    .Entity;
        }

        public async Task<Cause?> GetById(string causeId)
        {
            return await _context.Causes
                .Include(x => x.EquipmentClass)
                .Include(x => x.MaintenanceResponses)
                .FirstOrDefaultAsync(x => x.CauseId == causeId);
        }

        public async Task<List<Cause>> GetAll()
        {
            return await _context.Causes
                .AsNoTracking().ToListAsync();
        }

        public async Task Delete(string causeId)
        {
            var cause = await _context.Causes
                .FirstOrDefaultAsync(x => x.CauseId == causeId);

            if (cause is not null)
            {
                _context.Causes.Remove(cause);
            }
        }
    }
}
