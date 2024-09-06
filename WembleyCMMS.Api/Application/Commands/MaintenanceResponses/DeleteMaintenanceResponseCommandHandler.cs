using WembleyCMMS.Domain.AggregateModels.MaintenanceResponseAggregate;

namespace WembleyCMMS.Api.Application.Commands.MaintenanceResponses
{
    public class DeleteMaintenanceResponseCommandHandler : IRequestHandler<DeleteMaintenanceResponseCommand, bool>
    {
        private readonly IMaintenanceResponseRepository _maintenanceResponseRepository;

        public DeleteMaintenanceResponseCommandHandler(IMaintenanceResponseRepository maintenanceResponseRepository)
        {
            _maintenanceResponseRepository = maintenanceResponseRepository;
        }

        public async Task<bool> Handle(DeleteMaintenanceResponseCommand request, CancellationToken cancellationToken)
        {
            await _maintenanceResponseRepository.Delete(request.MaintenanceResponseId);
            return await _maintenanceResponseRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}
