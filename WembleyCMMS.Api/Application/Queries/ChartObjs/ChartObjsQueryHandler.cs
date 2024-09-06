//using WembleyCMMS.Api.Application.Queries.MaintenanceRequests;
//using WembleyCMMS.Domain.AggregateModels.ChartObjAggregate;
//using WembleyCMMS.Domain.AggregateModels.MaintenanceRequestAggregate;
//using WembleyCMMS.Infrastructure;

//namespace WembleyCMMS.Api.Application.Queries.ChartObjs
//{
//    public class ChartObjsQueryHandler : IRequestHandler<ChartObjsQuery, List<ChartObjViewModel>>
//    {
//        private readonly ApplicationDbContext _context;
//        private readonly IMapper _mapper;

//        public ChartObjsQueryHandler(ApplicationDbContext context, IMapper mapper)
//        {
//            _context = context;
//            _mapper = mapper;
//        }

//        public async Task<List<ChartObjViewModel>> Handle(ChartObjsQuery request, CancellationToken cancellationToken)
//        {
//            var result = await _context.ChartObjs.AsNoTracking().ToListAsync();

//            return _mapper.Map<List<ChartObj>, List<ChartObjViewModel>>(result);
//        }
//    }
//}
