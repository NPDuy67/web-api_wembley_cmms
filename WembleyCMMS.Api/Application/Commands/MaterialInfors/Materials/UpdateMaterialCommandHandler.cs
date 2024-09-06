using WembleyCMMS.Domain.AggregateModels.MaterialInforAggregate;

namespace WembleyCMMS.Api.Application.Commands.MaterialInfors.Materials
{
    public class UpdateMaterialCommandHandler : IRequestHandler<UpdateMaterialCommand, bool>
    {
        private readonly IMaterialInforRepository _materialInforRepository;

        public UpdateMaterialCommandHandler(IMaterialInforRepository materialInforRepository)
        {
            _materialInforRepository = materialInforRepository;
        }

        public async Task<bool> Handle(UpdateMaterialCommand request, CancellationToken cancellationToken)
        {
            var materialInfor = await _materialInforRepository.GetById(request.MaterialInforId) ?? throw new ResourceNotFoundException(nameof(MaterialInfor), request.MaterialInforId);
            materialInfor.UpdateMaterial(request.MaterialId, request.Status);
            return await _materialInforRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}
