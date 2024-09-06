using WembleyCMMS.Domain.AggregateModels.MaterialInforAggregate;

namespace WembleyCMMS.Api.Application.Commands.MaterialInfors.Materials
{
    public class CreateMaterialsCommandHandler : IRequestHandler<CreateMaterialsCommand, bool>
    {
        private readonly IMaterialInforRepository _materialInforRepository;

        public CreateMaterialsCommandHandler(IMaterialInforRepository materialInforRepository)
        {
            _materialInforRepository = materialInforRepository;
        }

        public async Task<bool> Handle(CreateMaterialsCommand request, CancellationToken cancellationToken)
        {
            foreach (var item in request.Materials)
            {
                var materialInfor = await _materialInforRepository.GetById(item.MaterialInforId) ?? throw new ResourceNotFoundException(nameof(MaterialInfor), item.MaterialInforId);

                var materialId = Guid.NewGuid().ToString();
                materialInfor.AddMaterial(materialId, item.Sku, item.Status);
            }

            return await _materialInforRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}
