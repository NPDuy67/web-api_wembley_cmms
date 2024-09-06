using WembleyCMMS.Api.Application.Queries.TimeSeriesObjects;
using WembleyCMMS.Domain.AggregateModels.TimeSeriesObjectAggregate;
using WembleyCMMS.Infrastructure;

namespace WembleyCMMS.Api.Application.Queries.TimeSeriesObjects
{
    public class TimeSeriesObjectByIdQueryHandler : IRequestHandler<TimeSeriesObjectByIdQuery, QueryResult<TimeSeriesObjectViewModel>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public TimeSeriesObjectByIdQueryHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<QueryResult<TimeSeriesObjectViewModel>> Handle(TimeSeriesObjectByIdQuery request, CancellationToken cancellationToken)
        {
            var queryable = _context.TimeSeriesObjects
                .AsNoTracking();

            if (request.TimeSeriesObjectId is not null)
            {
                queryable = queryable.Where(x => x.TimeSeriesObjectId == request.TimeSeriesObjectId);
            }

            int totalItems = await queryable.CountAsync();

            queryable = queryable
                .OrderBy(x => x.TimeSeriesObjectId)
                .Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize);

            var requests = await queryable.ToListAsync();
            var queryResult = new QueryResult<TimeSeriesObject>(requests, totalItems);

            return _mapper.Map<QueryResult<TimeSeriesObject>, QueryResult<TimeSeriesObjectViewModel>>(queryResult);
        }
    }
}
