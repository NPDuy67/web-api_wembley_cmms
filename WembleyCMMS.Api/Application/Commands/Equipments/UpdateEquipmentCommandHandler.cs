using WembleyCMMS.Domain.AggregateModels.EquipmentMaterialAggregate;
using WembleyCMMS.Domain.AggregateModels.PerformanceIndexAggregate;
using WembleyCMMS.Domain.AggregateModels.WorkingTimeAggregate;
using WembleyCMMS.Domain.AggregateModels.EquipmentClassAggregate;

namespace WembleyCMMS.Api.Application.Commands.Equipments
{
    public class UpdateEquipmentCommandHandler : IRequestHandler<UpdateEquipmentCommand, bool>
    {
        private readonly IEquipmentRepository _equipmentRepository;
        private readonly IEquipmentClassRepository _equipmentClassRepository;  
        private readonly IEquipmentMaterialRepository _equipmentMaterialRepository;
        private readonly IPerformanceIndexRepository _performanceIndexRepository;
        private readonly IWorkingTimeRepository _workingTimeRepository;

        public UpdateEquipmentCommandHandler(IEquipmentRepository equipmentRepository, 
                                             IEquipmentClassRepository equipmentClassRepository, 
                                             IEquipmentMaterialRepository equipmentMaterialRepository, 
                                             IPerformanceIndexRepository performanceIndexRepository, 
                                             IWorkingTimeRepository workingTimeRepository)
        {
            _equipmentRepository = equipmentRepository;
            _equipmentClassRepository = equipmentClassRepository;
            _equipmentMaterialRepository = equipmentMaterialRepository;
            _performanceIndexRepository = performanceIndexRepository;
            _workingTimeRepository = workingTimeRepository;
        }

        public async Task<bool> Handle(UpdateEquipmentCommand request, CancellationToken cancellationToken)
        {
            var equipmentClass = await _equipmentClassRepository.GetById(request.EquipmentClass) ?? throw new ResourceNotFoundException(nameof(EquipmentClass), request.EquipmentClass);
           
            var equipment = await _equipmentRepository.GetById(request.EquipmentId) ?? throw new ResourceNotFoundException(nameof(Equipment), request.EquipmentId);
            equipment.Update(code: request.Code,
                             name: request.Name,
                             equipmentClass: equipmentClass,
                             updatedAt: DateTime.Now);

            _equipmentRepository.Update(equipment);

            return await _equipmentRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}

