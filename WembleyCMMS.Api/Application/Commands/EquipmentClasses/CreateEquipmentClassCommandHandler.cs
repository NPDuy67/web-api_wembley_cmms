using WembleyCMMS.Domain.AggregateModels.EquipmentClassAggregate;

namespace WembleyCMMS.Api.Application.Commands.EquipmentClasses
{
    public class CreateEquipmentClassCommandHandler : IRequestHandler<CreateEquipmentClassCommand, bool>
    {
        private readonly IEquipmentClassRepository _equipmentClassRepository;

        public CreateEquipmentClassCommandHandler(IEquipmentClassRepository equipmentClassRepository)
        {
            _equipmentClassRepository = equipmentClassRepository;
        }

        public async Task<bool> Handle(CreateEquipmentClassCommand request, CancellationToken cancellationToken)
        {
            var equipmentClassId = Guid.NewGuid().ToString();
            var equipmentClass = new EquipmentClass(equipmentClassId, request.Name);
            
            _equipmentClassRepository.Add(equipmentClass);
            
            return await _equipmentClassRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken); 
        }
    }
}
