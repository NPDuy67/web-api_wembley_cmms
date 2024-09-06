using WembleyCMMS.Domain.AggregateModels.EquipmentClassAggregate;

namespace WembleyCMMS.Api.Application.Commands.EquipmentClasses
{
    public class DeleteEquipmentClassCommandHandler : IRequestHandler<DeleteEquipmentClassCommand, bool>
    {
        private readonly IEquipmentClassRepository _equipmentClassRepository;

        public DeleteEquipmentClassCommandHandler(IEquipmentClassRepository equipmentClassRepository)
        {
            _equipmentClassRepository = equipmentClassRepository;
        }

        public async Task<bool> Handle(DeleteEquipmentClassCommand request, CancellationToken cancellationToken)
        {
            await _equipmentClassRepository.Delete(request.EquipmentClassId);
            return await _equipmentClassRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}
