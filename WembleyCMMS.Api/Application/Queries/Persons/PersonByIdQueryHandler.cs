using WembleyCMMS.Domain.AggregateModels.PersonAggregate;
using WembleyCMMS.Domain.AggregateModels.WorkingTimeAggregate;
using WembleyCMMS.Infrastructure;

namespace WembleyCMMS.Api.Application.Queries.Persons
{
    public class PersonByIdQueryHandler : IRequestHandler<PersonByIdQuery, QueryResult<PersonViewModel>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;


        public PersonByIdQueryHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<QueryResult<PersonViewModel>> Handle(PersonByIdQuery request, CancellationToken cancellationToken)
        {
            var queryable = _context.Persons
                .AsNoTracking();

            if (request.PersonId is not null)
            {
                queryable = queryable.Where(x => x.PersonId == request.PersonId);
            }

            int totalItems = await queryable.CountAsync();

            if (request.Paginated)
            {
                queryable = queryable
                    .OrderBy(x => x.PersonId)
                    .Skip((request.PageIndex - 1) * request.PageSize)
                    .Take(request.PageSize);
            }

            var persons = await queryable.ToListAsync();

            var queryResult = new QueryResult<Person>(persons, totalItems);
            return _mapper.Map<QueryResult<Person>, QueryResult<PersonViewModel>>(queryResult);
        }
    }
}
