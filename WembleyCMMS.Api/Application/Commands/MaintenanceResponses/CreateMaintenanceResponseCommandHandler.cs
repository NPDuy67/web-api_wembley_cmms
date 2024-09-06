using WembleyCMMS.Domain.AggregateModels.CauseAggregate;
using WembleyCMMS.Domain.AggregateModels.CorrectionAggregate;
using WembleyCMMS.Domain.AggregateModels.MaintenanceResponseAggregate;
using WembleyCMMS.Domain.AggregateModels.PersonAggregate;
using WembleyCMMS.Domain.AggregateModels.EquipmentClassAggregate;
using WembleyCMMS.Domain.AggregateModels.MaintenanceRequestAggregate;
using WembleyCMMS.Domain.AggregateModels.MaterialInforAggregate;

namespace WembleyCMMS.Api.Application.Commands.MaintenanceResponses
{
    public class CreateMaintenanceResponseCommandHandler : IRequestHandler<CreateMaintenanceResponseCommand, bool>
    {
        private readonly IMaintenanceResponseRepository _maintenanceResponseRepository;
        private readonly IMaintenanceRequestRepository _maintenanceRequestRepository;
        private readonly IEquipmentClassRepository _equipmentClassRepository;
        private readonly IEquipmentRepository _equipmentRepository;
        private readonly IPersonRepository _personRepository;
        private readonly ICauseRepository _causeRepository;
        private readonly ICorrectionRepository _correctionRepository;
        public CreateMaintenanceResponseCommandHandler(IMaintenanceResponseRepository maintenanceResponseRepository,
                                                       IMaintenanceRequestRepository maintenanceRequestRepository,
                                                       IEquipmentClassRepository equipmentClassRepository,
                                                       IEquipmentRepository equipmentRepository,
                                                       IPersonRepository personRepository,
                                                       ICauseRepository causeRepository,
                                                       ICorrectionRepository correctionRepository)
        {
            _maintenanceResponseRepository = maintenanceResponseRepository;
            _maintenanceRequestRepository = maintenanceRequestRepository;
            _equipmentClassRepository = equipmentClassRepository;
            _equipmentRepository = equipmentRepository;
            _personRepository = personRepository;
            _causeRepository = causeRepository;
            _correctionRepository = correctionRepository;
        }

        public async Task<bool> Handle(CreateMaintenanceResponseCommand request, CancellationToken cancellationToken)
        {
            var equipmentClass = await _equipmentClassRepository.GetById(request.EquipmentClass) ?? throw new ResourceNotFoundException(nameof(EquipmentClass), request.EquipmentClass);
            var maintenanceRequest = await _maintenanceRequestRepository.GetById(request.Request) ?? throw new ResourceNotFoundException(nameof(MaintenanceRequest), request.Request);

            Equipment? equipment = request.Equipment is not null
                ? await _equipmentRepository.GetById(request.Equipment) ?? throw new ResourceNotFoundException(nameof(Equipment), request.Equipment)
                : null;

            Person? responsiblePerson = request.ResponsiblePerson is not null
                ? await _personRepository.GetById(request.ResponsiblePerson) ?? throw new ResourceNotFoundException(nameof(Person), request.ResponsiblePerson)
                : null;

            var maintenanceResponseId = Guid.NewGuid().ToString();

            var maintenanceResponses = await _maintenanceResponseRepository.GetAll();

            var code = maintenanceResponses.Count + 1;
            var maintenanceResponseCode = $"MRES-23{code.ToString().PadLeft(4, '0')}";

            while (maintenanceResponses.Any(x => x.Code == maintenanceResponseCode))
            {
                code = code + 1;
                maintenanceResponseCode = $"MRES-23{code.ToString().PadLeft(4, '0')}";
            }

            var maintenanceResponse = new MaintenanceResponse(maintenanceResponseId: maintenanceResponseId,
                                                              cause: new List<Cause>(), 
                                                              correction: new List<Correction>(), 
                                                              plannedStart: request.PlannedStart, 
                                                              plannedFinish: request.PlannedFinish, 
                                                              estProcessTime: request.EstProcessTime,
                                                              actualStartTime: request.ActualStartTime,
                                                              actualFinishTime: request.ActualFinishTime, 
                                                              status: request.Status,
                                                              createdAt: DateTime.Now,
                                                              updatedAt: DateTime.Now,
                                                              responsiblePerson: responsiblePerson,
                                                              priority: request.Priority, 
                                                              problem: request.Problem, 
                                                              images: null, 
                                                              materials: new List<Material>(),
                                                              code: maintenanceResponseCode,
                                                              note: request.Note,
                                                              request: maintenanceRequest,
                                                              equipmentClass: equipmentClass,
                                                              equipment: equipment,
                                                              dueDate: request.DueDate,
                                                              type: request.Type);

            _maintenanceResponseRepository.Add(maintenanceResponse);
            return await _maintenanceResponseRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}
