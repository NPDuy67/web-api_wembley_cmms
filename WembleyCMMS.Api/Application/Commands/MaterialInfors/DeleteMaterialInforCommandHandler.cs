using WembleyCMMS.Domain.AggregateModels.MaterialInforAggregate;

namespace WembleyCMMS.Api.Application.Commands.MaterialInfors
{
    public class DeleteMaterialInforCommandHandler : IRequestHandler<DeleteMaterialInforCommand, bool>
    {
        private readonly IMaterialInforRepository _materialInforRepository;

        public DeleteMaterialInforCommandHandler(IMaterialInforRepository materialInforRepository)
        {
            _materialInforRepository = materialInforRepository;
        }

        public async Task<bool> Handle(DeleteMaterialInforCommand request, CancellationToken cancellationToken)
        {
            await _materialInforRepository.Delete(request.MaterialInforId);
            return await _materialInforRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}
