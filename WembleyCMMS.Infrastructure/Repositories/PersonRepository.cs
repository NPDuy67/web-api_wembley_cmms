using WembleyCMMS.Domain.AggregateModels.PersonAggregate;

namespace WembleyCMMS.Infrastructure.Repositories
{
    public class PersonRepository : BaseRepository, IPersonRepository
    {
        public PersonRepository(ApplicationDbContext context) : base(context)
        {
        }

        public Person Add(Person person)
        {
            if (person.IsTransient())
            {
                return _context.Persons
                    .Add(person)
                    .Entity;
            }
            else
            {
                return person;
            }
        }

        public Person Update(Person person)
        {
            return _context.Persons
                    .Update(person)
                    .Entity;
        }

        public async Task<Person?> GetById(string personId)
        {
            return await _context.Persons
                .FirstOrDefaultAsync(x => x.PersonId == personId);
        }

        public async Task<List<Person>?> GetAll()
        {
            return await _context.Persons
                .AsNoTracking().ToListAsync();
        }

        public async Task Delete(string personId)
        {
            var person = await _context.Persons
                .FirstOrDefaultAsync(x => x.PersonId == personId);

            if (person is not null)
            {
                _context.Persons.Remove(person);
            }
        }
    }
}
