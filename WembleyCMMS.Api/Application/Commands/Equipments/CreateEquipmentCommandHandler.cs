using WembleyCMMS.Domain.AggregateModels.PerformanceIndexAggregate;
using WembleyCMMS.Domain.AggregateModels.EquipmentMaterialAggregate;
using WembleyCMMS.Domain.AggregateModels.EquipmentClassAggregate;

namespace WembleyCMMS.Api.Application.Commands.Equipments
{
    public class CreateEquipmentCommandHandler : IRequestHandler<CreateEquipmentCommand, bool>
    {
        private readonly IEquipmentRepository _equipmentRepository;
        private readonly IEquipmentClassRepository _equipmentClassRepository;
        private readonly IPerformanceIndexRepository _performanceIndexRepository;

        public CreateEquipmentCommandHandler(IEquipmentRepository equipmentRepository, 
                                             IEquipmentClassRepository equipmentClassRepository, 
                                             IPerformanceIndexRepository performanceIndexRepository)
        {
            _equipmentRepository = equipmentRepository;
            _equipmentClassRepository = equipmentClassRepository;
            _performanceIndexRepository = performanceIndexRepository;
        }

        public async Task<bool> Handle(CreateEquipmentCommand request, CancellationToken cancellationToken)
        {
            string MTBFString = Guid.NewGuid().ToString();
            var MTBF = new PerformanceIndex(MTBFString);
            _performanceIndexRepository.Add(MTBF);

            string MTTFString = Guid.NewGuid().ToString();
            var MTTF = new PerformanceIndex(MTTFString);
            _performanceIndexRepository.Add(MTTF);

            string OEEString = Guid.NewGuid().ToString();
            var OEE = new PerformanceIndex(OEEString);
            _performanceIndexRepository.Add(OEE);

            var equipmentClass = await _equipmentClassRepository.GetById(request.EquipmentClass) ?? throw new ResourceNotFoundException(nameof(EquipmentClass), request.EquipmentClass);

            var equipmentId = Guid.NewGuid().ToString();
            var equipment = new Equipment(equipmentId: equipmentId, 
                                          code: request.Code, 
                                          name: request.Name, 
                                          scheduleWorkingTimes: null, 
                                          equipmentClass: equipmentClass,
                                          mTBF: MTBF, 
                                          mTTF: MTTF, 
                                          oEE: OEE,
                                          updatedAt: DateTime.Now);
            _equipmentRepository.Add(equipment);

            return await _equipmentRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}
