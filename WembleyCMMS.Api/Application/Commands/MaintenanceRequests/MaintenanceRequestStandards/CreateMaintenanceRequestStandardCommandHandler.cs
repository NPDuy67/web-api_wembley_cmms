using WembleyCMMS.Domain.AggregateModels.EquipmentClassAggregate;
using WembleyCMMS.Domain.AggregateModels.MaintenanceRequestAggregate;
using WembleyCMMS.Domain.AggregateModels.PersonAggregate;
using static WembleyCMMS.Domain.AggregateModels.MaintenanceRequestAggregate.MaintenanceRequest;

namespace WembleyCMMS.Api.Application.Commands.MaintenanceRequests.MaintenanceRequestStandards
{
    public class CreateMaintenanceRequestStandardCommandHandler : IRequestHandler<CreateMaintenanceRequestStandardCommand, bool>
    {
        private readonly IMaintenanceRequestRepository _maintenanceRequestRepository;
        private readonly IEquipmentClassRepository _equipmentClassRepository;
        private readonly IPersonRepository _personRepository;

        public CreateMaintenanceRequestStandardCommandHandler(IMaintenanceRequestRepository maintenanceRequestRepository, IEquipmentClassRepository equipmentClassRepository, IPersonRepository personRepository)
        {
            _maintenanceRequestRepository = maintenanceRequestRepository;
            _equipmentClassRepository = equipmentClassRepository;
            _personRepository = personRepository;
        }

        public async Task<bool> Handle(CreateMaintenanceRequestStandardCommand request, CancellationToken cancellationToken)
        {
            var equipmentClass = await _equipmentClassRepository.GetById(request.EquipmentClass) ?? throw new ResourceNotFoundException(nameof(EquipmentClass), request.EquipmentClass);
            var requester = await _personRepository.GetById(request.Requester) ?? throw new ResourceNotFoundException(nameof(Person), request.Requester);
            var maintenanceRequests = await _maintenanceRequestRepository.GetAll();
            var standardCounts = maintenanceRequests.Count(x => x.Type == EMaintenanceType.Preventive);
            var maintenaceSchedule = GenerateMaintenanceSchedule(request.StartTime, request.EndTime, request.MaintenanceCycle);

            for (int i = 0; i < maintenaceSchedule.Count(); i++)
            {
                var maintenanceRequestId = Guid.NewGuid().ToString();
                var code = $"MREQSD-23{(standardCounts + 1 + i).ToString().PadLeft(4, '0')}";
                var maintenanceRequest = new MaintenanceRequest(maintenanceRequestId: maintenanceRequestId,
                                                                code: code,
                                                                problem: request.Problem,
                                                                requestedCompletionDate: DateTime.Now,
                                                                requestedPriority: null,
                                                                requester: requester,
                                                                status: EMaintenanceRequestStatus.Submitted,
                                                                reviewer: null,
                                                                submissionDate: DateTime.Now,
                                                                createdAt: DateTime.Now,
                                                                updatedAt: DateTime.Now,
                                                                type: EMaintenanceType.Preventive,
                                                                equipmentClass: equipmentClass,
                                                                equipment: null,
                                                                images: null,
                                                                responsiblePerson: null,
                                                                estProcessingTime: request.EstProcessingTime,
                                                                plannedStart: maintenaceSchedule[i]);

                _maintenanceRequestRepository.Add(maintenanceRequest);
            }

            return await _maintenanceRequestRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }

        private List<DateTime> GenerateMaintenanceSchedule(DateTime startTime, DateTime endTime, int maintenanceCycle)
        {
            List<DateTime> maintenanceDates = new List<DateTime>();
            DateTime maintenanceDate = startTime;

            while (maintenanceDate <= endTime)
            {
                maintenanceDates.Add(maintenanceDate);
                maintenanceDate = maintenanceDate.AddDays(maintenanceCycle);
            }

            return maintenanceDates;
        }
    }
}
