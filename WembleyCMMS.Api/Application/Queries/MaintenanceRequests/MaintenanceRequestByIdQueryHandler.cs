using WembleyCMMS.Infrastructure;
using static WembleyCMMS.Domain.AggregateModels.MaintenanceRequestAggregate.MaintenanceRequest;

namespace WembleyCMMS.Api.Application.Queries.MaintenanceRequests
{
    public class MaintenanceRequestByIdQueryHandler : IRequestHandler<MaintenanceRequestByIdQuery, QueryResult<MaintenanceRequestViewModel>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public MaintenanceRequestByIdQueryHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<QueryResult<MaintenanceRequestViewModel>> Handle(MaintenanceRequestByIdQuery request, CancellationToken cancellationToken)
        {
            var queryable = _context.MaintenanceRequests
                .Include(x => x.EquipmentClass)
                .Include(x => x.Equipment)
                .Include(x => x.Requester)
                .Include(x => x.Reviewer)
                .Include(x => x.ResponsiblePerson)
                .AsNoTracking();

            if (request.MaintenanceRequestId is not null)
            {
                queryable = queryable.Where(x => x.MaintenanceRequestId == request.MaintenanceRequestId);
            }

            int totalItems = await queryable.CountAsync();

            if (request.Paginated)
            {
                queryable = queryable
                    .OrderBy(x => x.MaintenanceRequestId)
                    .Skip((request.PageIndex - 1) * request.PageSize)
                    .Take(request.PageSize);
            }

            queryable = queryable.OrderBy(x => x.PlannedStart);

            var maintenanceRequests = await queryable.ToListAsync();

            var listGetViewModel = maintenanceRequests.Select(maintenanceRequest => new MaintenanceRequestGetViewModel(maintenanceRequest.MaintenanceRequestId)
            {
                Code = maintenanceRequest.Code,
                Problem = maintenanceRequest.Problem,
                RequestedCompletionDate = maintenanceRequest.RequestedCompletionDate,
                RequestedPriority = maintenanceRequest.RequestedPriority,
                Requester = maintenanceRequest.Requester,
                Status = maintenanceRequest.Status.ToString(),
                Reviewer = maintenanceRequest.Reviewer,
                SubmissionDate = maintenanceRequest.SubmissionDate,
                CreatedAt = maintenanceRequest.CreatedAt,
                UpdatedAt = maintenanceRequest.UpdatedAt,
                Type = maintenanceRequest.Type.ToString(),
                EquipmentClass = maintenanceRequest.EquipmentClass,
                Equipment = maintenanceRequest.Equipment,
                Images = string.IsNullOrEmpty(maintenanceRequest.Images) ? null : maintenanceRequest.Images.Split("|").ToList(),
                ResponsiblePerson = maintenanceRequest.ResponsiblePerson,
                EstProcessingTime = maintenanceRequest.EstProcessingTime,
                PlannedStart = maintenanceRequest.PlannedStart
            }).ToList();

            var queryResult = new QueryResult<MaintenanceRequestGetViewModel>(listGetViewModel, totalItems);
            return _mapper.Map<QueryResult<MaintenanceRequestGetViewModel>, QueryResult<MaintenanceRequestViewModel>>(queryResult);
        }
    }
}
