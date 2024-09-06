using WembleyCMMS.Domain.AggregateModels.MaterialInforAggregate;
using static WembleyCMMS.Domain.AggregateModels.MaterialInforAggregate.Material;

namespace WembleyCMMS.Api.Application.Commands.MaterialInfors.Materials
{
    public class CreateMaterialCommandHandler : IRequestHandler<CreateMaterialCommand, bool>
    {
        private readonly IMaterialInforRepository _materialInforRepository;

        public CreateMaterialCommandHandler(IMaterialInforRepository materialInforRepository)
        {
            _materialInforRepository = materialInforRepository;
        }

        public async Task<bool> Handle(CreateMaterialCommand request, CancellationToken cancellationToken)
        {
            var materialInfor = await _materialInforRepository.GetById(request.MaterialInforId) ?? throw new ResourceNotFoundException(nameof(MaterialInfor), request.MaterialInforId);

            var materialId = Guid.NewGuid().ToString();
            materialInfor.AddMaterial(materialId, request.Sku, EMaterialStatus.Available);

            return await _materialInforRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}
