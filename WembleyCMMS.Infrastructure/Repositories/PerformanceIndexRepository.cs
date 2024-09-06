using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WembleyCMMS.Domain.AggregateModels.PerformanceIndexAggregate;

namespace WembleyCMMS.Infrastructure.Repositories
{
    public class PerformanceIndexRepository : BaseRepository, IPerformanceIndexRepository
    {
        public PerformanceIndexRepository(ApplicationDbContext context) : base(context)
        {
        }

        public PerformanceIndex Add(PerformanceIndex performanceIndex)
        {
            if (performanceIndex.IsTransient())
            {
                return _context.PerformanceIndexs
                    .Add(performanceIndex)
                    .Entity;
            }
            else
            {
                return performanceIndex;
            }
        }

        public PerformanceIndex Update(PerformanceIndex performanceIndex)
        {
            return _context.PerformanceIndexs
                    .Update(performanceIndex)
                    .Entity;
        }

        public async Task<PerformanceIndex?> GetById(string performanceIndexId)
        {
            return await _context.PerformanceIndexs
                .FirstOrDefaultAsync(x => x.PerformanceIndexId == performanceIndexId);
        }

        public async Task Delete(string performanceIndexId)
        {
            var performanceIndex = await _context.PerformanceIndexs
                .FirstOrDefaultAsync(x => x.PerformanceIndexId == performanceIndexId);

            if (performanceIndex is not null)
            {
                _context.Remove(performanceIndex);
            }
        }
    }
}
