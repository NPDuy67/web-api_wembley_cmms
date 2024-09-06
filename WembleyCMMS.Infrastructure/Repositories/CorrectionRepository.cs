using WembleyCMMS.Domain.AggregateModels.CorrectionAggregate;

namespace WembleyCMMS.Infrastructure.Repositories
{
    public class CorrectionRepository : BaseRepository, ICorrectionRepository
    {
        public CorrectionRepository(ApplicationDbContext context) : base(context)
        {
        }

        public Correction Add(Correction correction)
        {
            if (correction.IsTransient())
            {
                return _context.Corrections
                    .Add(correction)
                    .Entity;
            }
            else
            {
                return correction;
            }
        }

        public Correction Update(Correction correction)
        {
            return _context.Corrections
                    .Update(correction)
                    .Entity;
        }

        public async Task<Correction?> GetById(string correctionId)
        {
            return await _context.Corrections
                .FirstOrDefaultAsync(x => x.CorrectionId == correctionId);
        }

        public async Task<List<Correction>> GetAll()
        {
            return await _context.Corrections
                .AsNoTracking().ToListAsync();
        }

        public async Task Delete(string correctionId)
        {
            var correction = await _context.Corrections
                .FirstOrDefaultAsync(x => x.CorrectionId == correctionId);

            if (correction is not null)
            {
                _context.Corrections.Remove(correction);
            }
        }
    }
}
