using WembleyCMMS.Domain.AggregateModels.InspectionReportAggregate;
using WembleyCMMS.Infrastructure;
using static WembleyCMMS.Domain.AggregateModels.EquipmentAggregate.Equipment;
using static WembleyCMMS.Domain.AggregateModels.InspectionReportAggregate.InspectionReport;
using static WembleyCMMS.Domain.AggregateModels.MaintenanceRequestAggregate.MaintenanceRequest;

namespace WembleyCMMS.Api.Application.Queries.MaintenanceResponses
{
    public class MaintenanceResponseByIdQueryHandler : IRequestHandler<MaintenanceResponseByIdQuery, QueryResult<MaintenanceResponseViewModel>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public MaintenanceResponseByIdQueryHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<QueryResult<MaintenanceResponseViewModel>> Handle(MaintenanceResponseByIdQuery request, CancellationToken cancellationToken)
        {
            var queryable = _context.MaintenanceResponses
                .Include(x => x.Cause)
                .Include(x => x.Correction)
                .Include(x => x.Materials)
                .ThenInclude(x => x.MaterialInfor)
                .Include(x => x.ResponsiblePerson)
                .Include(x => x.Request)
                .Include(x => x.EquipmentClass)
                .Include(x => x.Equipment)
                .Include(x => x.InspectionReports)
                .AsNoTracking();

            if (request.MaintenanceResponseId is not null)
            {
                queryable = queryable.Where(x => x.MaintenanceResponseId == request.MaintenanceResponseId);
            }

            int totalItems = await queryable.CountAsync();

            if (request.Paginated)
            {
                queryable = queryable
                    .OrderBy(x => x.MaintenanceResponseId)
                    .Skip((request.PageIndex - 1) * request.PageSize)
                    .Take(request.PageSize);
            }

            queryable = queryable.OrderBy(x => x.PlannedStart);

            var maintenanceResponses = await queryable.ToListAsync();

            var listGetViewModel = maintenanceResponses.Select(response => new MaintenanceResponseGetViewModel(response.MaintenanceResponseId)
            {
                Cause = response.Cause,
                Correction = response.Correction,
                PlannedStart = response.PlannedStart,
                PlannedFinish = response.PlannedFinish,
                EstProcessTime = response.EstProcessTime,
                ActualStartTime = response.ActualStartTime,
                ActualFinishTime = response.ActualFinishTime,
                Status = response.Status.ToString(),
                CreatedAt = response.CreatedAt,
                UpdatedAt = response.UpdatedAt,
                ResponsiblePerson = response.ResponsiblePerson,
                Priority = response.Priority,
                Problem = response.Problem,
                Images = string.IsNullOrEmpty(response.Images) ? null : response.Images.Split("|").ToList(),
                Materials = response.Materials,
                Code = response.Code,
                Note = response.Note,
                Request = response.Request,
                EquipmentClass = response.EquipmentClass,
                Equipment = response.Equipment,
                DueDate = response.DueDate,
                Type = response.Type.ToString(),
                InspectionReports = response.InspectionReports?.Select(report => new InspectionReportWithStatusString(
                    inspectionReportId: report.InspectionReportId,
                    name: report.Name,
                    group: report.Group,
                    status: report.Status.ToString(),
                    isRequest: report.IsRequest
                )).ToList()
            }).ToList();
            var queryResult = new QueryResult<MaintenanceResponseGetViewModel>(listGetViewModel, totalItems);

            return _mapper.Map<QueryResult<MaintenanceResponseGetViewModel>, QueryResult<MaintenanceResponseViewModel>>(queryResult);
        }
    }
}
