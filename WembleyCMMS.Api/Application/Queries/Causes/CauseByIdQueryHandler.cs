using WembleyCMMS.Api.Application.Queries.Causes;
using WembleyCMMS.Domain.AggregateModels.CauseAggregate;
using WembleyCMMS.Infrastructure;
using static WembleyCMMS.Domain.AggregateModels.CauseAggregate.Cause;
using static WembleyCMMS.Domain.AggregateModels.EquipmentAggregate.Equipment;
using static WembleyCMMS.Domain.AggregateModels.MaintenanceResponseAggregate.MaintenanceResponse;

namespace WembleyCMMS.Api.Application.Queries.Causes
{
    public class CauseByIdQueryHandler : IRequestHandler<CauseByIdQuery, QueryResult<CauseViewModel>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CauseByIdQueryHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<QueryResult<CauseViewModel>> Handle(CauseByIdQuery request, CancellationToken cancellationToken)
        {
            var queryable = _context.Causes
                .Include(x => x.EquipmentClass)
                .Include(x => x.MaintenanceResponses)
                .AsNoTracking();

            if (request.CauseId is not null)
            {
                queryable = queryable.Where(x => x.CauseId == request.CauseId);
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
