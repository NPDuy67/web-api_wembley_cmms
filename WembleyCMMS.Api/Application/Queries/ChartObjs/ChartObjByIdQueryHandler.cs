//using WembleyCMMS.Api.Application.Queries.MaintenanceRequests;
//using WembleyCMMS.Domain.AggregateModels.ChartObjAggregate;
//using WembleyCMMS.Domain.AggregateModels.MaintenanceRequestAggregate;
//using WembleyCMMS.Infrastructure;

//namespace WembleyCMMS.Api.Application.Queries.ChartObjs
//{
//    public class ChartObjByIdQueryHandler : IRequestHandler<ChartObjByIdQuery, QueryResult<ChartObjViewModel>>
//    {
//        private readonly ApplicationDbContext _context;
//        private readonly IMapper _mapper;

//        public ChartObjByIdQueryHandler(ApplicationDbContext context, IMapper mapper)
//        {
//            _context = context;
//            _mapper = mapper;
//        }

//        public async Task<QueryResult<ChartObjViewModel>> Handle(ChartObjByIdQuery request, CancellationToken cancellationToken)
//        {
//            var queryable = _context.ChartObjs
//                .AsNoTracking();

//            if (request.ChartObjId is not null)
//            {
//                queryable = queryable.Where(x => x.ChartObjId == request.ChartObjId);
//            }

//            int totalItems = await queryable.CountAsync();

//            queryable = queryable
//                .OrderBy(x => x.ChartObjId)
//                .Skip((request.PageIndex - 1) * request.PageSize)
//                .Take(request.PageSize);

//            var requests = await queryable.ToListAsync();
//            var queryResult = new QueryResult<ChartObj>(requests, totalItems);

//            return _mapper.Map<QueryResult<ChartObj>, QueryResult<ChartObjViewModel>>(queryResult);
//        }
//    }
//}
