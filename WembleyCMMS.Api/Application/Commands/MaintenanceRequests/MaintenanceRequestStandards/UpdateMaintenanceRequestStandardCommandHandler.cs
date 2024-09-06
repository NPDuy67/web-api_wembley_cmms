using WembleyCMMS.Domain.AggregateModels.CauseAggregate;
using WembleyCMMS.Domain.AggregateModels.CorrectionAggregate;
using WembleyCMMS.Domain.AggregateModels.MaintenanceRequestAggregate;
using WembleyCMMS.Domain.AggregateModels.MaintenanceResponseAggregate;
using WembleyCMMS.Domain.AggregateModels.MaterialInforAggregate;
using static WembleyCMMS.Domain.AggregateModels.MaintenanceRequestAggregate.MaintenanceRequest;

namespace WembleyCMMS.Api.Application.Commands.MaintenanceRequests.MaintenanceRequestStandards
{
    public class UpdateMaintenanceRequestStandardCommandHandler : IRequestHandler<UpdateMaintenanceRequestStandardCommand, bool>
    {
        private readonly IMaintenanceRequestRepository _maintenanceRequestRepository;
        private readonly IMaintenanceResponseRepository _maintenanceResponseRepository;
        private readonly IEquipmentRepository _equipmentRepository;

        public UpdateMaintenanceRequestStandardCommandHandler(IMaintenanceRequestRepository maintenanceRequestRepository, IMaintenanceResponseRepository maintenanceResponseRepository, IEquipmentRepository equipmentRepository)
        {
            _maintenanceRequestRepository = maintenanceRequestRepository;
            _maintenanceResponseRepository = maintenanceResponseRepository;
            _equipmentRepository = equipmentRepository;
        }

        public async Task<bool> Handle(UpdateMaintenanceRequestStandardCommand request, CancellationToken cancellationToken)
        {
            var maintenanceRequests = await _maintenanceRequestRepository.GetAll();
            var maintenanceRequestStandards = maintenanceRequests.Where(x => x.EquipmentClass.EquipmentClassId == request.EquipmentClass && x.Type == EMaintenanceType.Preventive && x.Status == EMaintenanceRequestStatus.Submitted);
            
            var maintenanceResponses = await _maintenanceResponseRepository.GetAll();
            var maintenanceResponseCounts = maintenanceResponses.Count(x => x.Type == EMaintenanceType.Preventive);

            var equipments = await _equipmentRepository.GetByEquipmentClassId(request.EquipmentClass) ?? throw new ResourceNotFoundException($"The entity of type 'Equipment' with EquipmentClassID '{request.EquipmentClass}' cannot be found.");

            if (request.Status == EMaintenanceRequestStatus.Approved)
            {
                int position = 0;
                foreach (var maintenanceRequestStandard in maintenanceRequestStandards)
                {
                    foreach (var equipment in equipments)
                    {
                        string maintenanceResponseId = Guid.NewGuid().ToString();
                        var code = $"MRESSD-23{(maintenanceResponseCounts + 1 + position).ToString().PadLeft(4, '0')}";

                        var maintenanceResponse = new MaintenanceResponse(maintenanceResponseId: maintenanceResponseId,
                                                                          cause: new List<Cause>(),
                                                                          correction: new List<Correction>(),
                                                                          plannedStart: maintenanceRequestStandard.PlannedStart,
                                                                          plannedFinish: maintenanceRequestStandard.EstProcessingTime is not null ? maintenanceRequestStandard.PlannedStart.AddMinutes((int)maintenanceRequestStandard.EstProcessingTime) : null,
                                                                          estProcessTime: maintenanceRequestStandard.EstProcessingTime,
                                                                          actualStartTime: null,
                                                                          actualFinishTime: null,
                                                                          status: Equipment.EMaintenanceStatus.Assigned,
                                                                          createdAt: DateTime.Now,
                                                                          updatedAt: DateTime.Now,
                                                                          responsiblePerson: null,
                                                                          priority: null,
                                                                          problem: maintenanceRequestStandard.Problem,
                                                                          images: null,
                                                                          materials: new List<Material>(),
                                                                          code: code,
                                                                          note: null,
                                                                          request: maintenanceRequestStandard,
                                                                          equipmentClass: maintenanceRequestStandard.EquipmentClass,
                                                                          equipment: equipment,
                                                                          dueDate: null,
                                                                          type: maintenanceRequestStandard.Type);
                        _maintenanceResponseRepository.Add(maintenanceResponse);

                        position++;
                    }

                    maintenanceRequestStandard.Status = EMaintenanceRequestStatus.Approved;
                    _maintenanceRequestRepository.Update(maintenanceRequestStandard);
                }
            }

            return await _maintenanceResponseRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}
