using WembleyCMMS.Domain.AggregateModels.CauseAggregate;
using WembleyCMMS.Domain.AggregateModels.EquipmentClassAggregate;
using WembleyCMMS.Domain.AggregateModels.MaintenanceResponseAggregate;

namespace WembleyCMMS.Api.Application.Commands.Causes
{
    public class UpdateCauseCommandHandler : IRequestHandler<UpdateCauseCommand, bool>
    {
        private readonly ICauseRepository _causeRepository;
        private readonly IMaintenanceResponseRepository _maintenanceResponseRepository;
        private readonly IEquipmentClassRepository _equipmentClassRepository;

        public UpdateCauseCommandHandler(ICauseRepository causeRepository, IMaintenanceResponseRepository maintenanceResponseRepository, IEquipmentClassRepository equipmentClassRepository)
        {
            _causeRepository = causeRepository;
            _maintenanceResponseRepository = maintenanceResponseRepository;
            _equipmentClassRepository = equipmentClassRepository;
        }

        public async Task<bool> Handle(UpdateCauseCommand request, CancellationToken cancellationToken)
        {
            var cause = await _causeRepository.GetById(request.CauseId) ?? throw new ResourceNotFoundException(nameof(Cause), request.CauseId);
            var equipmentClass = await _equipmentClassRepository.GetById(request.EquipmentClass) ?? throw new ResourceNotFoundException(nameof(EquipmentClass), request.EquipmentClass);

            cause.Update(request.CauseCode, request.CauseName, equipmentClass, request.Severity, request.Note);
            _causeRepository.Update(cause);

            return await _causeRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}
