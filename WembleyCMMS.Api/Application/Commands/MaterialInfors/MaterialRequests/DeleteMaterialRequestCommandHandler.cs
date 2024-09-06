using System.Runtime.CompilerServices;
using WembleyCMMS.Domain.AggregateModels.MaterialInforAggregate;

namespace WembleyCMMS.Api.Application.Commands.MaterialInfors.MaterialRequests
{
    public class DeleteMaterialRequestCommandHandler : IRequestHandler<DeleteMaterialRequestCommand, bool>
    {
        private readonly IMaterialInforRepository _materialInforRepository;

        public DeleteMaterialRequestCommandHandler(IMaterialInforRepository materialInforRepository)
        {
            _materialInforRepository = materialInforRepository;
        }

        public async Task<bool> Handle(DeleteMaterialRequestCommand request, CancellationToken cancellationToken)
        {
            var materialInfor = await _materialInforRepository.GetById(request.MaterialInforId) ?? throw new ResourceNotFoundException(nameof(MaterialInfor), request.MaterialInforId);
            materialInfor.RemoveMaterialRequest(request.MaterialRequestId);
            return await _materialInforRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}
