namespace WembleyCMMS.Domain.AggregateModels.CauseAggregate
{
    public interface ICauseRepository : IRepository<Cause>
    {
        public Cause Add(Cause cause);
        public Cause Update(Cause cause);
        public Task<Cause?> GetById(string causeId);
        public Task<List<Cause>> GetAll();
        public Task Delete(string causeId);
    }
}
