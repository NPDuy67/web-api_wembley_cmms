using WembleyCMMS.Domain.AggregateModels.PerformanceIndexAggregate;

namespace WembleyCMMS.Domain.AggregateModels.PerformanceIndexAggregate
{
    public interface IPerformanceIndexRepository : IRepository<PerformanceIndex>
    {
        public PerformanceIndex Add(PerformanceIndex performanceIndex);
        public PerformanceIndex Update(PerformanceIndex performanceIndex);
        public Task<PerformanceIndex?> GetById(string performanceIndexId);
        public Task Delete (string performanceIndexId);
    }
}
