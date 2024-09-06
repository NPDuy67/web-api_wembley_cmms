namespace WembleyCMMS.Domain.AggregateModels.CorrectionAggregate
{
    public interface ICorrectionRepository : IRepository<Correction>
    {
        public Correction Add(Correction correction);
        public Correction Update(Correction correction);
        public Task<Correction?> GetById(string correctionId);
        public Task<List<Correction>> GetAll();
        public Task Delete(string correctionId);
    }
}
