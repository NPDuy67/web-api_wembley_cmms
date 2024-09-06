using WembleyCMMS.Domain.AggregateModels.PerformanceIndexAggregate;
using WembleyCMMS.Infrastructure;

namespace WembleyCMMS.Api.Application.Queries.PerformanceIndexs
{
    public class PerformanceIndexsQueryHandler : IRequestHandler<PerformanceIndexsQuery, QueryResult<PerformanceIndexViewModel>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public PerformanceIndexsQueryHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<QueryResult<PerformanceIndexViewModel>> Handle(PerformanceIndexsQuery request, CancellationToken cancellationToken)
        {
            var queryable = _context.PerformanceIndexs
                .Include(x => x.History)
                .AsNoTracking();

            if (request.IdStartedWith is not null)
            {
                queryable = queryable.Where(x => x.PerformanceIndexId.StartsWith(request.IdStartedWith));
            }

            int totalItems = await queryable.CountAsync();

            if (request.Paginated)
            {
                queryable = queryable
                    .OrderBy(x => x.PerformanceIndexId)
                    .Skip((request.PageIndex - 1) * request.PageSize)
                    .Take(request.PageSize);
            }

            var performanceIndexs = await queryable.ToListAsync();
            var queryResult = new QueryResult<PerformanceIndex>(performanceIndexs, totalItems);

            return _mapper.Map<QueryResult<PerformanceIndex>, QueryResult<PerformanceIndexViewModel>>(queryResult);
        }
    }
}
