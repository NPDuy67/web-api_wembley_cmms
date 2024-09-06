using WembleyCMMS.Domain.AggregateModels.CauseAggregate;
using WembleyCMMS.Domain.AggregateModels.MaintenanceResponseAggregate;
using WembleyCMMS.Infrastructure;
using static WembleyCMMS.Domain.AggregateModels.CauseAggregate.Cause;
using static WembleyCMMS.Domain.AggregateModels.MaintenanceResponseAggregate.MaintenanceResponse;

namespace WembleyCMMS.Api.Application.Queries.Causes
{
    public class CausesQueryHandler : IRequestHandler<CausesQuery, QueryResult<CauseViewModel>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IMaintenanceResponseRepository _maintenanceResponseRepository;

        public CausesQueryHandler(ApplicationDbContext context, IMapper mapper,
                                  IMaintenanceResponseRepository maintenanceResponseRepository)
        {
            _context = context;
            _mapper = mapper;
            _maintenanceResponseRepository = maintenanceResponseRepository;
        }

        public async Task<QueryResult<CauseViewModel>> Handle(CausesQuery request, CancellationToken cancellationToken)
        {
            var queryable = _context.Causes
                .Include(x => x.EquipmentClass)
                .Include(x => x.MaintenanceResponses)
                .AsNoTracking();

            if (request.IdStartedWith is not null)
            {
                queryable = queryable.Where(x => x.CauseId.StartsWith(request.IdStartedWith));
            }

            int totalItems = await queryable.CountAsync();

            if (request.Paginated)
            {
                queryable = queryable
                    .OrderBy(x => x.CauseId)
                    .Skip((request.PageIndex - 1) * request.PageSize)
                    .Take(request.PageSize);
            }

            var causes = await queryable.ToListAsync();

            var listGetViewModel = new List<CauseGetViewModel>();
            foreach (Cause cause in causes)
            {
                var newGetViewModel = new CauseGetViewModel(cause.CauseId);
                newGetViewModel.CauseCode = cause.CauseCode;
                newGetViewModel.CauseName = cause.CauseName;
                newGetViewModel.EquipmentClass = cause.EquipmentClass;
                newGetViewModel.Severity = cause.Severity.ToString();
                newGetViewModel.Note = cause.Note;
                listGetViewModel.Add(newGetViewModel);
            }

            var queryResult = new QueryResult<CauseGetViewModel>(listGetViewModel, totalItems);
            return _mapper.Map<QueryResult<CauseGetViewModel>, QueryResult<CauseViewModel>>(queryResult);
        }
    }
}
