using WembleyCMMS.Domain.AggregateModels.MaterialInforAggregate;
using static WembleyCMMS.Domain.AggregateModels.MaterialInforAggregate.MaterialRequest;

namespace WembleyCMMS.Api.Application.Commands.MaterialInfors.MaterialRequests
{
    public class CreateMaterialRequestCommandHandler : IRequestHandler<CreateMaterialRequestCommand, bool>
    {
        private readonly IMaterialInforRepository _materialInforRepository;

        public CreateMaterialRequestCommandHandler(IMaterialInforRepository materialInforRepository)
        {
            _materialInforRepository = materialInforRepository;
        }

        public async Task<bool> Handle(CreateMaterialRequestCommand request, CancellationToken cancellationToken)
        {
            var materialInfor = await _materialInforRepository.GetById(request.MaterialInforId) ?? throw new ResourceNotFoundException(nameof(MaterialInfor), request.MaterialInforId);
            var materialInfors = await _materialInforRepository.GetAll();
            var materialRequestCounts = materialInfors.SelectMany(x => x.MaterialRequests).Count();
            var currentNumber = materialInfor.MaterialHistoryCards.Any() ? materialInfor.MaterialHistoryCards.Last().After : 0;

            var materialRequestId = Guid.NewGuid().ToString();
            var code = $"MATREQ-23{(materialRequestCounts + 1).ToString().PadLeft(4, '0')}";
            
            materialInfor.AddMaterialRequest(materialRequestId, code, currentNumber, request.AdditionalNumber, request.ExpectedNumber, request.ExpectedDate, DateTime.Now, DateTime.Now, EMaterialRequestStatus.InProgress);
            return await _materialInforRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}
