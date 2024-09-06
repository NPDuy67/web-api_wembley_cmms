using WembleyCMMS.Domain.AggregateModels.CauseAggregate;
using WembleyCMMS.Domain.AggregateModels.ChartObjAggregate;
using WembleyCMMS.Domain.AggregateModels.EquipmentMaterialAggregate;
using WembleyCMMS.Domain.AggregateModels.MaintenanceResponseAggregate;
using WembleyCMMS.Domain.AggregateModels.MaterialInforAggregate;
using WembleyCMMS.Domain.AggregateModels.PerformanceIndexAggregate;
using WembleyCMMS.Domain.AggregateModels.WorkingTimeAggregate;
using WembleyCMMS.Infrastructure;

namespace WembleyCMMS.Api.Application.Queries.Equipments
{
    public class EquipmentsQueryHandler : IRequestHandler<EquipmentsQuery, QueryResult<EquipmentViewModel>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IWorkingTimeRepository _workingTimeRepository;
        private readonly IMaintenanceResponseRepository _maintenanceResponseRepository;
        private readonly ICauseRepository _causeRepository;
        private readonly IEquipmentMaterialRepository _equipmentMaterialRepository;
        private readonly IMaterialInforRepository _materialInforRepository;
        private readonly IEquipmentRepository _equipmentRepository;
        private readonly IPerformanceIndexRepository _performanceIndexRepository;

        public EquipmentsQueryHandler(ApplicationDbContext context, IMapper mapper, 
                                      IWorkingTimeRepository workingTimeRepository,
                                      IMaintenanceResponseRepository maintenanceResponseRepository, 
                                      ICauseRepository causeRepository,
                                      IEquipmentMaterialRepository equipmentMaterialRepository,
                                      IMaterialInforRepository materialInforRepository,
                                      IEquipmentRepository equipmentRepository,
                                      IPerformanceIndexRepository performanceIndexRepository)
        {
            _context = context;
            _mapper = mapper;
            _workingTimeRepository = workingTimeRepository;
            _maintenanceResponseRepository = maintenanceResponseRepository;
            _causeRepository = causeRepository;
            _equipmentMaterialRepository = equipmentMaterialRepository;
            _materialInforRepository = materialInforRepository;
            _equipmentRepository = equipmentRepository;
            _performanceIndexRepository = performanceIndexRepository;
        }

        public async Task<QueryResult<EquipmentViewModel>> Handle(EquipmentsQuery request, CancellationToken cancellationToken)
        {
            var queryable = _context.Equipments
                .Include(x => x.EquipmentClass)
                .Include(x => x.MTBF)
                .ThenInclude(x => x.History)
                .Include(x => x.MTTF)
                .ThenInclude(x => x.History)
                .Include(x => x.OEE)
                .ThenInclude(x => x.History)
                .Include(x => x.Materials)
                .ThenInclude(x => x.MaterialInfor)
                .AsNoTracking();

            if (request.IdStartedWith is not null)
            {
                queryable = queryable.Where(x => x.EquipmentId.StartsWith(request.IdStartedWith));
            }

            if (request.EquipmentClassId is not null)
            {
                queryable = queryable.Where(x => x.EquipmentClass.EquipmentClassId == request.EquipmentClassId);
            }

            if (request.Paginated)
            {
                queryable = queryable
                    .OrderBy(x => x.EquipmentId)
                    .Skip((request.PageIndex - 1) * request.PageSize)
                    .Take(request.PageSize);
            }

            var totalItems = await queryable.CountAsync();

            var equipments = await queryable.ToListAsync();

            DateTime today = DateTime.Now;
            //foreach (var equipment in equipments)
            //{
            //    var getEquipment = await _equipmentRepository.GetById(equipment.EquipmentId) ?? throw new ResourceNotFoundException(nameof(Equipment), equipment.EquipmentId);
            //    var workingTimes = await _workingTimeRepository.GetByEquipmentId(equipment.EquipmentId);
            //    if (workingTimes is not null)
            //    {
            //        getEquipment.UsedTime = getEquipment.CalculateUsedTimeForEquipment(workingTimes, today);
            //        var listMaintenanceResponse = await _maintenanceResponseRepository.GetListByEquipmentId(getEquipment.EquipmentId);

            //        if (getEquipment.MTBF is not null)
            //        {
            //            getEquipment.MTBF.RecentValue = getEquipment.CalculateRepairFailure(listMaintenanceResponse);
            //            _performanceIndexRepository.Update(getEquipment.MTBF);
            //            await _performanceIndexRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
            //        }

            //        if (getEquipment.MTTF is not null)
            //        {
            //            getEquipment.MTTF.RecentValue = getEquipment.CalculateReplaceFailure(listMaintenanceResponse);
            //            _performanceIndexRepository.Update(getEquipment.MTTF);
            //            await _performanceIndexRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
            //        }

            //        _equipmentRepository.Update(getEquipment);
            //        await _equipmentRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
            //    }

            //    if (getEquipment.Materials != null && workingTimes != null)
            //    {
            //        var listEquipmentMaterial = new List<EquipmentMaterial>();
            //        foreach (EquipmentMaterial equipmentMaterial in getEquipment.Materials)
            //        {
            //            equipmentMaterial.UsedTime = equipmentMaterial.CalculateUsedTimeForEquipmentMaterial(workingTimes, today);
            //            _equipmentMaterialRepository.Update(equipmentMaterial);
            //            await _equipmentMaterialRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
            //        }
            //    }
            //}

            var listEquipmentGet = new List<EquipmentGetModel>();
            foreach (var equipment in equipments)
            {
                var equipmentGet = new EquipmentGetModel(equipment.EquipmentId);
                equipmentGet.Code = equipment.Code;
                equipmentGet.Name = equipment.Name;
                equipmentGet.EquipmentClass = equipment.EquipmentClass;
                equipmentGet.MTBF = equipment.MTBF;
                equipmentGet.MTTF = equipment.MTTF;
                equipmentGet.OEE = equipment.OEE;
                equipmentGet.Status = equipment.Status.ToString();
                var listMaintenanceResponse = await _maintenanceResponseRepository.GetListByEquipmentId(equipment.EquipmentId);
                equipmentGet.UsedTime = equipment.UsedTime;
                equipmentGet.Errors = ChartObj.ConvertFromCauseToChartObj(listMaintenanceResponse);
                equipmentGet.Materials = equipment.Materials;

                listEquipmentGet.Add(equipmentGet);
            }

            var queryResult = new QueryResult<EquipmentGetModel>(listEquipmentGet, totalItems);

            return _mapper.Map<QueryResult<EquipmentGetModel>, QueryResult<EquipmentViewModel>>(queryResult);
        }
    }
}
