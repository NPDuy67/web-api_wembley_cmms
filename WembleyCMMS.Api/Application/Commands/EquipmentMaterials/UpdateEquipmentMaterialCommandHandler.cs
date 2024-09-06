using WembleyCMMS.Api.Application.Commands.EquipmentMaterials;
using WembleyCMMS.Api.Application.Exceptions;
using WembleyCMMS.Domain.AggregateModels.EquipmentMaterialAggregate;
using WembleyCMMS.Domain.AggregateModels.MaterialInforAggregate;

namespace WembleyCMMS.Api.Application.Commands.EquipmentEquipmentMaterials
{
    public class UpdateEquipmentMaterialCommandHandler : IRequestHandler<UpdateEquipmentMaterialCommand, bool>
    {
        private readonly IEquipmentMaterialRepository _equipmentMaterialRepository;
        private readonly IMaterialInforRepository _materialInforRepository;

        public UpdateEquipmentMaterialCommandHandler(IEquipmentMaterialRepository equipmentMaterialRepository, IMaterialInforRepository materialInforRepository)
        {
            _equipmentMaterialRepository = equipmentMaterialRepository;
            _materialInforRepository = materialInforRepository;
        }

        public async Task<bool> Handle(UpdateEquipmentMaterialCommand request, CancellationToken cancellationToken)
        {
            var materialInfor = await _materialInforRepository.GetById(request.MaterialInforId) ?? throw new ResourceNotFoundException(nameof(MaterialInfor), request.MaterialInforId);

            var equipmentMaterial = await _equipmentMaterialRepository.GetById(request.EquipmentMaterialId) ?? throw new ResourceNotFoundException(nameof(EquipmentMaterial), request.EquipmentMaterialId);
            equipmentMaterial.Update(materialInfor: materialInfor, 
                                     fullTime: request.FullTime, 
                                     usedTime: request.UsedTime,
                                     installedTime: request.InstalledTime, 
                                     updateAt: DateTime.Now);
            _equipmentMaterialRepository.Update(equipmentMaterial);

            return await _equipmentMaterialRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}
