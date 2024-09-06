using WembleyCMMS.Domain.AggregateModels.CauseAggregate;
using WembleyCMMS.Domain.AggregateModels.EquipmentClassAggregate;
using WembleyCMMS.Domain.AggregateModels.MaintenanceResponseAggregate;

namespace WembleyCMMS.Api.Application.Commands.Causes
{
    public class CreateCauseCommandHandler : IRequestHandler<CreateCauseCommand, bool>
    {
        private readonly ICauseRepository _causeRepository;
        private readonly IMaintenanceResponseRepository _maintenanceResponseRepository;
        private readonly IEquipmentClassRepository _equipmentClassRepository;

        public CreateCauseCommandHandler(ICauseRepository causeRepository, IMaintenanceResponseRepository maintenanceResponseRepository, IEquipmentClassRepository equipmentClassRepository)
        {
            _causeRepository = causeRepository;
            _maintenanceResponseRepository = maintenanceResponseRepository;
            _equipmentClassRepository = equipmentClassRepository;
        }

        public async Task<bool> Handle(CreateCauseCommand request, CancellationToken cancellationToken)
        {
            var equipmentClass = await _equipmentClassRepository.GetById(request.EquipmentClass) ?? throw new ResourceNotFoundException(nameof(EquipmentClass), request.EquipmentClass);

            string causeId = Guid.NewGuid().ToString();
            var listCause = await _causeRepository.GetAll();
            var code = listCause.Count + 1;
            var causeCode = $"CAU-{code.ToString().PadLeft(4, '0')}";

            while (listCause.Any(x => x.CauseCode == causeCode))
            {
                code = code + 1;
                causeCode = $"CAU-{code.ToString().PadLeft(4, '0')}";
            }

            var cause = new Cause(causeId: causeId,
                                  causeCode: causeCode,
                                  causeName: request.CauseName,
                                  equipmentClass: equipmentClass,
                                  severity: request.Severity,
                                  note: request.Note);
            _causeRepository.Add(cause);

            return await _causeRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}
