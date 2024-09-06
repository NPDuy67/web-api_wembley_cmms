using WembleyCMMS.Domain.AggregateModels.MaterialInforAggregate;

namespace WembleyCMMS.Api.Application.Commands.MaterialInfors.MaterialHistoryCards
{
    public class UpdateMaterialHistoryCardCommandHandler : IRequestHandler<UpdateMaterialHistoryCardCommand, bool>
    {
        private readonly IMaterialInforRepository _materialInforRepository;

        public UpdateMaterialHistoryCardCommandHandler(IMaterialInforRepository materialInforRepository)
        {
            _materialInforRepository = materialInforRepository;
        }

        public async Task<bool> Handle(UpdateMaterialHistoryCardCommand request, CancellationToken cancellationToken)
        {
            var materialInfor = await _materialInforRepository.GetById(request.MaterialInforId) ?? throw new ResourceNotFoundException(nameof(MaterialInfor), request.MaterialInforId);

            materialInfor.UpdateMaterialHistoryCard(request.MaterialHistoryCardId, request.TimeStamp, request.Before, request.Input, request.Output, request.After, request.Note);
            return await _materialInforRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}
