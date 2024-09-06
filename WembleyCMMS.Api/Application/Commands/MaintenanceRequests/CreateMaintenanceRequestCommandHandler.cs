using WembleyCMMS.Domain.AggregateModels.PersonAggregate;
using WembleyCMMS.Domain.AggregateModels.MaintenanceRequestAggregate;
using static WembleyCMMS.Domain.AggregateModels.MaintenanceRequestAggregate.MaintenanceRequest;
using WembleyCMMS.Domain.AggregateModels.EquipmentClassAggregate;

namespace WembleyCMMS.Api.Application.Commands.MaintenanceRequests
{
    public class CreateMaintenanceRequestCommandHandler : IRequestHandler<CreateMaintenanceRequestCommand, bool>
    {
        private readonly IMaintenanceRequestRepository _maintenanceRequestRepository;
        private readonly IEquipmentClassRepository _equipmentClassRepository;
        private readonly IEquipmentRepository _equipmentRepository;
        private readonly IPersonRepository _personRepository;

        public CreateMaintenanceRequestCommandHandler(IMaintenanceRequestRepository maintenanceRequestRepository,
                                                      IEquipmentClassRepository equipmentClassRepository, 
                                                      IEquipmentRepository equipmentRepository, 
                                                      IPersonRepository personRepository)
        {
            _maintenanceRequestRepository = maintenanceRequestRepository;
            _equipmentClassRepository = equipmentClassRepository;
            _equipmentRepository = equipmentRepository;
            _personRepository = personRepository;
        }

        public async Task<bool> Handle(CreateMaintenanceRequestCommand request, CancellationToken cancellationToken)
        {
            var equipmentClass = await _equipmentClassRepository.GetById(request.EquipmentClass) ?? throw new ResourceNotFoundException(nameof(EquipmentClass), request.EquipmentClass);

            Equipment? equipment = request.Equipment is not null
                ? await _equipmentRepository.GetById(request.Equipment) ?? throw new ResourceNotFoundException(nameof(Equipment), request.Equipment)
                : null;

            var requester         = await GetPersonByIdOrNull(request.Requester);
            var reviewer          = await GetPersonByIdOrNull(request.Reviewer);
            var responsiblePerson = await GetPersonByIdOrNull(request.ResponsiblePerson);

            string? listImage = request.Images is not null
                ? string.Join("|", request.Images)
                : null;

            var maintenanceRequestId = Guid.NewGuid().ToString();
            var maintenanceRequests = await _maintenanceRequestRepository.GetAll();

            var code = maintenanceRequests.Count + 1;
            var maintenanceRequestCode = $"MREQ-23{code.ToString().PadLeft(4, '0')}";

            while (maintenanceRequests.Any(x => x.Code == maintenanceRequestCode))
            {
                code = code + 1;
                maintenanceRequestCode = $"MREQ-23{code.ToString().PadLeft(4, '0')}";
            }

            var maintenanceRequest = new MaintenanceRequest(maintenanceRequestId: maintenanceRequestId,
                                                            code: maintenanceRequestCode,
                                                            problem: request.Problem,
                                                            requestedCompletionDate: request.RequestedCompletionDate, 
                                                            requestedPriority: request.RequestedPriority,
                                                            requester: requester,
                                                            status: EMaintenanceRequestStatus.Submitted,
                                                            reviewer: reviewer,
                                                            submissionDate: DateTime.Now,
                                                            createdAt: DateTime.Now,
                                                            updatedAt: DateTime.Now,
                                                            type: request.Type,
                                                            equipmentClass: equipmentClass,
                                                            equipment: equipment,
                                                            images: listImage,
                                                            responsiblePerson: responsiblePerson,
                                                            estProcessingTime: request.EstProcessingTime,
                                                            plannedStart: request.PlannedStart);

            _maintenanceRequestRepository.Add(maintenanceRequest);

            return await _maintenanceRequestRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }


        private async Task<Person?> GetPersonByIdOrNull(string? personId)
        {
            if (string.IsNullOrEmpty(personId))
                return null;

            var person = await _personRepository.GetById(personId) ?? throw new ResourceNotFoundException(nameof(Person), personId);
            return person;
        }
    }
}
