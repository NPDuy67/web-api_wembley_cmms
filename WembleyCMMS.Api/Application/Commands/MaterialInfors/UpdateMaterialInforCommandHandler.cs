using WembleyCMMS.Domain.AggregateModels.MaterialInforAggregate;

namespace WembleyCMMS.Api.Application.Commands.MaterialInfors
{
    public class UpdateMaterialInforCommandHandler : IRequestHandler<UpdateMaterialInforCommand, bool>
    {
        private readonly IMaterialInforRepository _materialInforRepository;

        public UpdateMaterialInforCommandHandler(IMaterialInforRepository materialInforRepository)
        {
            _materialInforRepository = materialInforRepository;
        }

        public async Task<bool> Handle(UpdateMaterialInforCommand request, CancellationToken cancellationToken)
        {
            var materialInfor = await _materialInforRepository.GetById(request.MaterialInforId) ?? throw new ResourceNotFoundException(nameof(MaterialInfor), request.MaterialInforId);
            materialInfor.Update(code: request.Code,
                                 name: request.Name,
                                 unit: request.Unit,
                                 minimumQuantity: request.MinimumQuantity);
            _materialInforRepository.Update(materialInfor);

            return await _materialInforRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}
