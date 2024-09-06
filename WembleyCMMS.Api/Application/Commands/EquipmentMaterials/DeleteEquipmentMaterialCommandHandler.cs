using WembleyCMMS.Domain.AggregateModels.EquipmentMaterialAggregate;

namespace WembleyCMMS.Api.Application.Commands.EquipmentMaterials
{
    public class DeleteEquipmentMaterialCommandHandler : IRequestHandler<DeleteEquipmentMaterialCommand, bool>  
    {
        private readonly IEquipmentMaterialRepository _equipmentMaterialRepository;

        public DeleteEquipmentMaterialCommandHandler(IEquipmentMaterialRepository equipmentMaterialRepository)
        {
            _equipmentMaterialRepository = equipmentMaterialRepository;
        }

        public async Task<bool> Handle(DeleteEquipmentMaterialCommand request, CancellationToken cancellationToken)
        {
            await _equipmentMaterialRepository.Delete(request.EquipmentMaterialId);
            return await _equipmentMaterialRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}
