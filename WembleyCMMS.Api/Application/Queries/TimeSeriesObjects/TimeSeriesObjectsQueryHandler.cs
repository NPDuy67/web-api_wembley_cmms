﻿using WembleyCMMS.Api.Application.Queries.TimeSeriesObjects;
using WembleyCMMS.Domain.AggregateModels.TimeSeriesObjectAggregate;
using WembleyCMMS.Infrastructure;

namespace WembleyCMMS.Api.Application.Queries.TimeSeriesObjects
{
    public class TimeSeriesObjectsQueryHandler : IRequestHandler<TimeSeriesObjectsQuery, List<TimeSeriesObjectViewModel>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public TimeSeriesObjectsQueryHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<TimeSeriesObjectViewModel>> Handle(TimeSeriesObjectsQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.TimeSeriesObjects.AsNoTracking().ToListAsync();

            return _mapper.Map<List<TimeSeriesObject>, List<TimeSeriesObjectViewModel>>(result);
        }
    }
}
