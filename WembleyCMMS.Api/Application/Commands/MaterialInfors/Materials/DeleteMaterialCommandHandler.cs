using WembleyCMMS.Domain.AggregateModels.MaterialInforAggregate;

namespace WembleyCMMS.Api.Application.Commands.MaterialInfors.Materials
{
    public class DeleteMaterialCommandHandler : IRequestHandler<DeleteMaterialCommand, bool>
    {
        private readonly IMaterialInforRepository _materialInforRepository;

        public DeleteMaterialCommandHandler(IMaterialInforRepository materialInforRepository)
        {
            _materialInforRepository = materialInforRepository;
        }

        public async Task<bool> Handle(DeleteMaterialCommand request, CancellationToken cancellationToken)
        {
            var materialInfor = await _materialInforRepository.GetById(request.MaterialInforId) ?? throw new ResourceNotFoundException(nameof(MaterialInfor), request.MaterialInforId);
            materialInfor.RemoveMaterial(request.MaterialId);
            return await _materialInforRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}
