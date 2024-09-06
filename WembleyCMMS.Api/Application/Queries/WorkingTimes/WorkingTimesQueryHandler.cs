using WembleyCMMS.Domain.AggregateModels.WorkingTimeAggregate;
using WembleyCMMS.Infrastructure;

namespace WembleyCMMS.Api.Application.Queries.WorkingTimes
{
    public class WorkingTimesQueryHandler : IRequestHandler<WorkingTimesQuery, QueryResult<WorkingTimeViewModel>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public WorkingTimesQueryHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<QueryResult<WorkingTimeViewModel>> Handle(WorkingTimesQuery request, CancellationToken cancellationToken)
        {
            var queryable = _context.WorkingTimes
                .Include(x => x.ResponsiblePerson)
                .Include(x => x.Equipment)
                .AsNoTracking();

            if (request.IdStartedWith is not null)
            {
                queryable = queryable.Where(x => x.WorkingTimeId.StartsWith(request.IdStartedWith));
            }

            if (request.PersonId is not null)
            {
                queryable = queryable.Where(x => x.ResponsiblePerson.PersonId == request.PersonId);
            }

            if (request.EquipmentId is not null)
            {
                queryable = queryable.Where(x => x.Equipment.EquipmentId == request.EquipmentId);
            }

            int totalItems = await queryable.CountAsync();

            if (request.Paginated)
            {
                queryable = queryable
                    .OrderBy(x => x.WorkingTimeId)
                    .Skip((request.PageIndex - 1) * request.PageSize)
                    .Take(request.PageSize);
            }

            var workingTimes = await queryable.ToListAsync();
            var queryResult = new QueryResult<WorkingTime>(workingTimes, totalItems);

            return _mapper.Map<QueryResult<WorkingTime>, QueryResult<WorkingTimeViewModel>>(queryResult);
        }
    }
}
