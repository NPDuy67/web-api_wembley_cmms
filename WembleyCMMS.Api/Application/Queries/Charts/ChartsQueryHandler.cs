using WembleyCMMS.Domain.AggregateModels.ChartObjAggregate;
using WembleyCMMS.Domain.AggregateModels.MaintenanceResponseAggregate;
using WembleyCMMS.Infrastructure;
using static WembleyCMMS.Domain.AggregateModels.EquipmentAggregate.Equipment;
using static WembleyCMMS.Domain.AggregateModels.MaintenanceRequestAggregate.MaintenanceRequest;

namespace WembleyCMMS.Api.Application.Queries.Charts
{
    public class ChartsQueryHandler : IRequestHandler<ChartsQuery, ChartViewModel>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IMaintenanceResponseRepository _maintenanceResponseRepository;

        public ChartsQueryHandler(ApplicationDbContext context, IMapper mapper, IMaintenanceResponseRepository maintenanceResponseRepository)
        {
            _context = context;
            _mapper = mapper;
            _maintenanceResponseRepository = maintenanceResponseRepository;
        }

        public async Task<ChartViewModel> Handle(ChartsQuery request, CancellationToken cancellationToken)
        {
            var queryable = _context.MaintenanceResponses
                .Include(x => x.Cause)
                .AsNoTracking();

            if (request.TimeInterval is not null)
            {
                if (request.TimeInterval == ETimeInterval.Day)
                {
                    queryable = queryable.Where(x => x.PlannedStart.Date == DateTime.Now.Date);
                }
                else if (request.TimeInterval == ETimeInterval.Month)
                {
                    queryable = queryable.Where(x => x.PlannedStart.Month == DateTime.Now.Month);
                }
                else if (request.TimeInterval == ETimeInterval.Year)
                {
                    queryable = queryable.Where(x => x.PlannedStart.Year == DateTime.Now.Year);
                }   
            }

            var maintenanceResponses = await queryable.ToListAsync();

            var reactiveMaintenances = maintenanceResponses.Where(x => x.Type == EMaintenanceType.Reactive).ToList();
            var preventiveMaintenances = maintenanceResponses.Where(x => x.Type == EMaintenanceType.Preventive).ToList();

            int reactiveTotal = reactiveMaintenances.Count();
            int reactiveCompleted = reactiveMaintenances.Count(x => x.Status == EMaintenanceStatus.Completed);
            int reactiveCompletionRate = reactiveMaintenances.Count() > 0 ? (int)((double)reactiveCompleted / reactiveMaintenances.Count() * 100) : 0;

            int preventiveTotal = preventiveMaintenances.Count();
            int preventiveCompleted = preventiveMaintenances.Count(x => x.Status == EMaintenanceStatus.Completed);
            int preventiveCompletionRate = preventiveMaintenances.Count() > 0 ? (int)((double)preventiveCompleted / preventiveMaintenances.Count() * 100) : 0;

            int reactiveToPreventiveRate = preventiveMaintenances.Count() > 0 ? (int)((double)reactiveMaintenances.Count() / preventiveMaintenances.Count() * 100) : 0;

            int onTimePreventive = preventiveMaintenances.Count(x => x.Status == EMaintenanceStatus.Completed && x.ActualFinishTime <= x.PlannedFinish);
            int overDuePreventive = preventiveMaintenances.Count(x => x.Status == EMaintenanceStatus.Completed && x.ActualFinishTime > x.PlannedFinish);
            int overDuePreventiveInCompleted = preventiveMaintenances.Count(x => x.Status != EMaintenanceStatus.Completed && DateTime.Now > x.PlannedFinish);

            var equipments = await _context.Equipments
                .AsNoTracking()
                .ToListAsync();

            var equipmentCauses = new List<EquipmentCauseViewModel>();
            foreach (var equipment in equipments)
            {
                var listMaintenanceResponses = await _maintenanceResponseRepository.GetListByEquipmentId(equipment.EquipmentId);
                var listChartObjs = ChartObj.ConvertFromCauseToChartObj(listMaintenanceResponses);
                var equipmentCause = new EquipmentCauseViewModel(equipment.EquipmentId, equipment.Code, equipment.Name, listChartObjs);
                equipmentCauses.Add(equipmentCause);
            }

            var viewModel = new ChartViewModel(
                reactiveTotal: reactiveTotal,
                reactiveCompleted: reactiveCompleted,
                reactiveCompletionRate: reactiveCompletionRate,
                preventiveTotal: preventiveTotal,
                preventiveCompleted: preventiveCompleted,
                preventiveCompletionRate: preventiveCompletionRate,
                reactiveToPreventiveRate: reactiveToPreventiveRate,
                onTimePreventive: onTimePreventive,
                overDuePreventive: overDuePreventive,
                overDuePreventiveInCompleted: overDuePreventiveInCompleted,
                equipmentCauses: equipmentCauses
            );

            return viewModel;
        }
    }
}
