using WembleyCMMS.Domain.AggregateModels.PersonAggregate;
using WembleyCMMS.Domain.AggregateModels.MaintenanceRequestAggregate;
using static WembleyCMMS.Domain.AggregateModels.MaintenanceRequestAggregate.MaintenanceRequest;
using WembleyCMMS.Domain.AggregateModels.MaintenanceResponseAggregate;
using WembleyCMMS.Domain.AggregateModels.EquipmentClassAggregate;
using WembleyCMMS.Domain.AggregateModels.CauseAggregate;
using WembleyCMMS.Domain.AggregateModels.CorrectionAggregate;
using WembleyCMMS.Domain.AggregateModels.MaterialInforAggregate;

namespace WembleyCMMS.Api.Application.Commands.MaintenanceRequests
{
    public class UpdateMaintenanceRequestCommandHandler : IRequestHandler<UpdateMaintenanceRequestCommand, bool>
    {
        private readonly IMaintenanceRequestRepository _maintenanceRequestRepository;
        private readonly IEquipmentClassRepository _equipmentClassRepository;
        private readonly IEquipmentRepository _equipmentRepository;
        private readonly IPersonRepository _personRepository;
        private readonly IMaintenanceResponseRepository _maintenanceResponseRepository;

        public UpdateMaintenanceRequestCommandHandler(IMaintenanceRequestRepository maintenanceRequestRepository,
                                                      IEquipmentClassRepository equipmentClassRepository, 
                                                      IEquipmentRepository equipmentRepository,
                                                      IPersonRepository personRepository,
                                                      IMaintenanceResponseRepository maintenanceResponseRepository)
        {
            _maintenanceRequestRepository = maintenanceRequestRepository;
            _equipmentClassRepository = equipmentClassRepository;
            _equipmentRepository = equipmentRepository;
            _personRepository = personRepository;
            _maintenanceResponseRepository = maintenanceResponseRepository;
        }

        public async Task<bool> Handle(UpdateMaintenanceRequestCommand request, CancellationToken cancellationToken)
        {
            EquipmentClass? equipmentClass = request.EquipmentClass is not null
                ? await _equipmentClassRepository.GetById(request.EquipmentClass) ?? throw new ResourceNotFoundException(nameof(EquipmentClass), request.EquipmentClass)
                : null;

            Equipment? equipment = request.Equipment is not null
                ? await _equipmentRepository.GetById(request.Equipment) ?? throw new ResourceNotFoundException(nameof(Equipment), request.Equipment)
                : null;

            var requester         = await GetPersonByIdOrNull(request.Requester);
            var reviewer          = await GetPersonByIdOrNull(request.Reviewer);
            var responsiblePerson = await GetPersonByIdOrNull(request.ResponsiblePerson);

            string? listImage = request.Images is not null
                ? string.Join("|", request.Images)
                : null;

            var maintenanceRequest = await _maintenanceRequestRepository.GetById(request.MaintenanceRequestId) ?? throw new ResourceNotFoundException(nameof(MaintenanceRequest), request.MaintenanceRequestId);

            maintenanceRequest.Update(code: request.Code,
                                      problem: request.Problem,
                                      requestedCompletionDate: request.RequestedCompletionDate,
                                      requestedPriority: request.RequestedPriority,
                                      requester: requester,
                                      status: request.Status,
                                      reviewer: reviewer,
                                      submissionDate: request.SubmissionDate,
                                      updatedAt: DateTime.Now,
                                      type: request.Type,
                                      equipmentClass: equipmentClass,
                                      equipment: equipment,
                                      images: listImage,
                                      responsiblePerson: responsiblePerson,
                                      estProcessingTime: request.EstProcessingTime,
                                      plannedStart: request.PlannedStart);

            if (request.Status == EMaintenanceRequestStatus.Approved)
            {
                string maintenanceResponseId = Guid.NewGuid().ToString();
                var maintenanceResponses = await _maintenanceResponseRepository.GetAll();
                var code = $"MRES-23{(maintenanceResponses.Count + 1).ToString().PadLeft(4, '0')}";

                var person = await GetPersonByIdOrNull(request.ResponsiblePerson);
                if (person is null && maintenanceRequest.ResponsiblePerson is not null)
                {
                    person = await GetPersonByIdOrNull(maintenanceRequest.ResponsiblePerson.PersonId);
                }

                var maintenanceResponse = new MaintenanceResponse(maintenanceResponseId: maintenanceResponseId,
                                                                  cause: new List<Cause>(),
                                                                  correction: new List<Correction>(),
                                                                  plannedStart: maintenanceRequest.PlannedStart,
                                                                  plannedFinish: null,
                                                                  estProcessTime: maintenanceRequest.EstProcessingTime,
                                                                  actualStartTime: null,
                                                                  actualFinishTime: null,
                                                                  status: Equipment.EMaintenanceStatus.Assigned,
                                                                  createdAt: DateTime.Now,
                                                                  updatedAt: DateTime.Now,
                                                                  responsiblePerson: person,
                                                                  priority: maintenanceRequest.RequestedPriority,
                                                                  problem: maintenanceRequest.Problem,
                                                                  images: null,
                                                                  materials: new List<Material>(),
                                                                  code: code,
                                                                  note: null,
                                                                  request: maintenanceRequest,
                                                                  equipmentClass: maintenanceRequest.EquipmentClass,
                                                                  equipment: maintenanceRequest.Equipment,
                                                                  dueDate: null,
                                                                  type: maintenanceRequest.Type);
                _maintenanceResponseRepository.Add(maintenanceResponse);
                await _maintenanceResponseRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
            }

            _maintenanceRequestRepository.Update(maintenanceRequest);
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
