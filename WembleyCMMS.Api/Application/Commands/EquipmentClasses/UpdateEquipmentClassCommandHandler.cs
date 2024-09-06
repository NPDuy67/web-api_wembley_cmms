using WembleyCMMS.Domain.AggregateModels.EquipmentClassAggregate;

namespace WembleyCMMS.Api.Application.Commands.EquipmentClasses
{
    public class UpdateEquipmentClassCommandHandler : IRequestHandler<UpdateEquipmentClassCommand, bool>
    {
        private readonly IEquipmentClassRepository _equipmentClassRepository;

        public UpdateEquipmentClassCommandHandler(IEquipmentClassRepository equipmentClassRepository)
        {
            _equipmentClassRepository = equipmentClassRepository;
        }

        public async Task<bool> Handle(UpdateEquipmentClassCommand request, CancellationToken cancellationToken)
        {
            var equipmentClass = await _equipmentClassRepository.GetById(request.EquipmentClassId) ?? throw new ResourceNotFoundException(nameof(EquipmentClass), request.EquipmentClassId);

            equipmentClass.Update(request.Name);
            _equipmentClassRepository.Update(equipmentClass);

            return await _equipmentClassRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}
