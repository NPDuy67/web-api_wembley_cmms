using WembleyCMMS.Domain.AggregateModels.MaintenanceRequestAggregate;

namespace WembleyCMMS.Api.Application.Commands.MaintenanceRequests
{
    public class DeleteMaintenanceRequestCommandHandler : IRequestHandler<DeleteMaintenanceRequestCommand, bool>
    {
        private readonly IMaintenanceRequestRepository _maintenanceRequestRepository;

        public DeleteMaintenanceRequestCommandHandler(IMaintenanceRequestRepository maintenanceRequestRepository)
        {
            _maintenanceRequestRepository = maintenanceRequestRepository;
        }

        public async Task<bool> Handle(DeleteMaintenanceRequestCommand request, CancellationToken cancellationToken)
        {
            await _maintenanceRequestRepository.Delete(request.MaintenanceRequestId);
            return await _maintenanceRequestRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}
