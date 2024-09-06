using WembleyCMMS.Domain.AggregateModels.MaterialInforAggregate;
using static WembleyCMMS.Domain.AggregateModels.MaterialInforAggregate.MaterialRequest;

namespace WembleyCMMS.Api.Application.Commands.MaterialInfors.MaterialRequests
{
    public class UpdateMaterialRequestCommandHandler : IRequestHandler<UpdateMaterialRequestCommand, bool>
    {
        private readonly IMaterialInforRepository _materialInforRepository;

        public UpdateMaterialRequestCommandHandler(IMaterialInforRepository materialInforRepository)
        {
            _materialInforRepository = materialInforRepository;
        }

        public async Task<bool> Handle(UpdateMaterialRequestCommand request, CancellationToken cancellationToken)
        {
            var materialInfor = await _materialInforRepository.GetById(request.MaterialInforId) ?? throw new ResourceNotFoundException(nameof(MaterialInfor), request.MaterialInforId);
            materialInfor.UpdateMaterialRequest(request.MaterialRequestId, request.CurrentNumber, request.AdditionalNumber, request.ExpectedNumber, request.ExpectedDate, DateTime.Now, request.Status);

            if (request.Status == EMaterialRequestStatus.Completed)
            {
                var materialRequest = materialInfor.GetMaterialRequest(request.MaterialRequestId);
                materialInfor.InputMaterialHistoryCard(materialRequest);
            }

            return await _materialInforRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}
