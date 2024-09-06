namespace WembleyCMMS.Domain.AggregateModels.PersonAggregate
{
    public interface IPersonRepository : IRepository<Person>
    {
        public Person Add(Person person);
        public Person Update(Person person);
        public Task<Person?> GetById(string personId);
        public Task<List<Person>?> GetAll();
        public Task Delete(string personId);
    }
}
