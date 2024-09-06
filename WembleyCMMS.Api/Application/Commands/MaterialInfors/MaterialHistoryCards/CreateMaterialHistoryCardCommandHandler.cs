using WembleyCMMS.Domain.AggregateModels.MaterialInforAggregate;

namespace WembleyCMMS.Api.Application.Commands.MaterialInfors.MaterialHistoryCards
{
    public class CreateMaterialHistoryCardCommandHandler : IRequestHandler<CreateMaterialHistoryCardCommand, bool>
    {
        private readonly IMaterialInforRepository _materialInforRepository;

        public CreateMaterialHistoryCardCommandHandler(IMaterialInforRepository materialInforRepository)
        {
            _materialInforRepository = materialInforRepository;
        }

        public async Task<bool> Handle(CreateMaterialHistoryCardCommand request, CancellationToken cancellationToken)
        {
            var materialInfor = await _materialInforRepository.GetById(request.MaterialInforId) ?? throw new ResourceNotFoundException(nameof(MaterialInfor), request.MaterialInforId);

            var materialHistoryCardId = Guid.NewGuid().ToString();
            materialInfor.AddMaterialHistoryCard(materialHistoryCardId, request.TimeStamp, request.Before, request.Input, request.Output, request.After, request.Note);

            return await _materialInforRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}
