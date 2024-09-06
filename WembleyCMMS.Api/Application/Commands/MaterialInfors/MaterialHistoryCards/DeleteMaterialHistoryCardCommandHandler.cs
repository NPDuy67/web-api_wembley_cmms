using WembleyCMMS.Domain.AggregateModels.MaterialInforAggregate;

namespace WembleyCMMS.Api.Application.Commands.MaterialInfors.MaterialHistoryCards
{
    public class DeleteMaterialHistoryCardCommandHandler : IRequestHandler<DeleteMaterialHistoryCardCommand, bool>
    {
        private readonly IMaterialInforRepository _materialInforRepository;

        public DeleteMaterialHistoryCardCommandHandler(IMaterialInforRepository materialInforRepository)
        {
            _materialInforRepository = materialInforRepository;
        }

        public async Task<bool> Handle(DeleteMaterialHistoryCardCommand request, CancellationToken cancellationToken)
        {
            var materialInfor = await _materialInforRepository.GetById(request.MaterialInforId) ?? throw new ResourceNotFoundException(nameof(MaterialInfor), request.MaterialInforId);
            materialInfor.RemoveMaterialHistoryCard(request.MaterialHistoryCardId);

            return await _materialInforRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}
