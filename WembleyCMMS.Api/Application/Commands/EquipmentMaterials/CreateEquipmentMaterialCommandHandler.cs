﻿using WembleyCMMS.Domain.AggregateModels.EquipmentMaterialAggregate;
using WembleyCMMS.Domain.AggregateModels.MaterialInforAggregate;

namespace WembleyCMMS.Api.Application.Commands.EquipmentMaterials
{
    public class CreateEquipmentMaterialCommandHandler : IRequestHandler<CreateEquipmentMaterialCommand, bool>
    {
        private readonly IEquipmentMaterialRepository _equipmentMaterialRepository;
        private readonly IEquipmentRepository _equipmentRepository;
        private readonly IMaterialInforRepository _materialInforRepository;

        public CreateEquipmentMaterialCommandHandler(IEquipmentMaterialRepository equipmentMaterialRepository, IEquipmentRepository equipmentRepository, IMaterialInforRepository materialInforRepository)
        {
            _equipmentMaterialRepository = equipmentMaterialRepository;
            _equipmentRepository = equipmentRepository;
            _materialInforRepository = materialInforRepository;
        }

        public async Task<bool> Handle(CreateEquipmentMaterialCommand request, CancellationToken cancellationToken)
        {
            var materialInfor = await _materialInforRepository.GetById(request.MaterialInforId) ?? throw new ResourceNotFoundException(nameof(MaterialInfor), request.MaterialInforId);
            var equipment = await _equipmentRepository.GetById(request.EquipmentId) ?? throw new ResourceNotFoundException(nameof(Equipment), request.EquipmentId);

            if (equipment.Materials.Any(x => x.MaterialInfor == materialInfor))
            {
                throw new EntityAlreadyExistsException(nameof(Equipment), equipment.EquipmentId, nameof(MaterialInfor), materialInfor.MaterialInforId);
            }

            string equipmentMaterialId = Guid.NewGuid().ToString();
            var equipmentMaterial = new EquipmentMaterial(equipmentMaterialId: equipmentMaterialId,
                                                          equipment: equipment,
                                                          materialInfor: materialInfor, 
                                                          fullTime: request.FullTime, 
                                                          usedTime: 0, 
                                                          installedTime: DateTime.Now,
                                                          updateAt: DateTime.Now);
            _equipmentMaterialRepository.Add(equipmentMaterial);

            return await _equipmentMaterialRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}
