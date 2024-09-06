using System.Threading;
using WembleyCMMS.Domain.AggregateModels.CauseAggregate;
using WembleyCMMS.Domain.AggregateModels.CorrectionAggregate;
using WembleyCMMS.Domain.AggregateModels.EquipmentClassAggregate;
using WembleyCMMS.Domain.AggregateModels.EquipmentMaterialAggregate;
using WembleyCMMS.Domain.AggregateModels.InspectionReportAggregate;
using WembleyCMMS.Domain.AggregateModels.MaintenanceResponseAggregate;
using WembleyCMMS.Domain.AggregateModels.MaterialInforAggregate;
using WembleyCMMS.Domain.AggregateModels.PerformanceIndexAggregate;
using WembleyCMMS.Domain.AggregateModels.PersonAggregate;
using WembleyCMMS.Domain.AggregateModels.WorkingTimeAggregate;
using static WembleyCMMS.Domain.AggregateModels.EquipmentAggregate.Equipment;
using static WembleyCMMS.Domain.AggregateModels.InspectionReportAggregate.InspectionReport;


namespace WembleyCMMS.Api.Application.Commands.MaintenanceResponses
{
    public class UpdateMaintenanceResponseCommandHandler : IRequestHandler<UpdateMaintenanceResponseCommand, bool>
    {
        private readonly IMaintenanceResponseRepository _maintenanceResponseRepository;
        private readonly IEquipmentClassRepository _equipmentClassRepository;
        private readonly IEquipmentRepository _equipmentRepository;
        private readonly IPersonRepository _personRepository;
        private readonly IWorkingTimeRepository _workingTimeRepository;
        private readonly ICauseRepository _causeRepository;
        private readonly ICorrectionRepository _correctionRepository;
        private readonly IEquipmentMaterialRepository _equipmentMaterialRepository;
        private readonly IPerformanceIndexRepository _performanceIndexRepository;
        private readonly IMaterialInforRepository _materialInforRepository;
        private readonly IInspectionReportRepository _inspectionReportRepository;

        public UpdateMaintenanceResponseCommandHandler(IMaintenanceResponseRepository maintenanceResponseRepository,
                                                       IEquipmentClassRepository equipmentClassRepository, 
                                                       IEquipmentRepository equipmentRepository,
                                                       IPersonRepository personRepository,
                                                       IWorkingTimeRepository workingTimeRepository,
                                                       ICauseRepository causeRepository,
                                                       ICorrectionRepository correctionRepository,
                                                       IEquipmentMaterialRepository equipmentMaterialRepository,
                                                       IPerformanceIndexRepository performanceIndexRepository,
                                                       IMaterialInforRepository materialInforRepository,
                                                       IInspectionReportRepository inspectionReportRepository)
        {
            _maintenanceResponseRepository = maintenanceResponseRepository;
            _equipmentClassRepository = equipmentClassRepository;
            _equipmentRepository = equipmentRepository;
            _personRepository = personRepository;
            _workingTimeRepository = workingTimeRepository;
            _causeRepository = causeRepository;
            _correctionRepository = correctionRepository;
            _equipmentMaterialRepository = equipmentMaterialRepository;
            _performanceIndexRepository = performanceIndexRepository;
            _materialInforRepository = materialInforRepository;
            _inspectionReportRepository = inspectionReportRepository;
        }

        public async Task<bool> Handle(UpdateMaintenanceResponseCommand request, CancellationToken cancellationToken)
        {
            EquipmentClass? equipmentClass = request.EquipmentClass is not null
                ? await _equipmentClassRepository.GetById(request.EquipmentClass) ?? throw new ResourceNotFoundException(nameof(EquipmentClass), request.EquipmentClass)
                : null;

            Equipment? equipment = request.Equipment is not null
                ? await _equipmentRepository.GetById(request.Equipment) ?? throw new ResourceNotFoundException(nameof(Equipment), request.Equipment)
                : null;

            Person? responsiblePerson = request.ResponsiblePerson is not null
                 ? await _personRepository.GetById(request.ResponsiblePerson) ?? throw new ResourceNotFoundException(nameof(Person), request.ResponsiblePerson)
                 : null;

            List<Cause>? listCause = request.Cause is not null 
                ? request.Cause.Select(causeId => _causeRepository.GetById(causeId).Result ?? throw new ResourceNotFoundException(nameof(Cause), causeId)).ToList() 
                : null;

            List<Correction>? listCorrection = request.Correction is not null
                ? request.Correction.Select(correctionId => _correctionRepository.GetById(correctionId).Result ?? throw new ResourceNotFoundException(nameof(Correction), correctionId)).ToList()
                : null;

            string? listImage = request.Images is not null
                ? string.Join("|", request.Images)
                : null;

            List<Material>? listMaterial = request.Materials is not null 
                ? request.Materials.Select(materialId => _materialInforRepository.GetMaterialById(materialId).Result ?? throw new ResourceNotFoundException(nameof(Material), materialId)).ToList() 
                : null;

            var maintenanceResponse = await _maintenanceResponseRepository.GetById(request.MaintenanceResponseId) ?? throw new ResourceNotFoundException(nameof(MaintenanceResponse), request.MaintenanceResponseId);

            if (maintenanceResponse.Status == EMaintenanceStatus.Completed)
            {
                throw new Exception("Completed MaintenanceReponse can not be edited");
            }

            List<InspectionReport>? listInspectionReport = null;
            if (request.InspectionReports != null)
            {
                if (maintenanceResponse.InspectionReports != null)
                {
                    foreach (InspectionReport inspectionReport in maintenanceResponse.InspectionReports)
                    {
                        InspectionReport existReport = await _inspectionReportRepository.GetById(inspectionReport.InspectionReportId) ?? throw new ResourceNotFoundException(nameof(InspectionReport), inspectionReport.InspectionReportId);
                        await _inspectionReportRepository.DeleteAsync(existReport.InspectionReportId);
                    }
                }

                listInspectionReport = new List<InspectionReport>();
                foreach(InspectionReportPut report in request.InspectionReports)
                {
                    var newReportId = Guid.NewGuid().ToString();
                    EPreventiveInspectionStatus reportStatus;
                    Enum.TryParse<EPreventiveInspectionStatus>(report.Status, out reportStatus);

                    var newReport = new InspectionReport(inspectionReportId: newReportId,
                                                         name: report.Name,
                                                         group: report.Group,
                                                         status: reportStatus,
                                                         isRequest: report.IsRequest);

                    _inspectionReportRepository.Update(newReport);
                    await _inspectionReportRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
                    listInspectionReport.Add(newReport);
                }
            }

            maintenanceResponse.Update(cause: listCause, 
                                       correction: listCorrection, 
                                       plannedStart: request.PlannedStart, 
                                       plannedFinish: request.PlannedFinish, 
                                       estProcessTime: request.EstProcessTime,
                                       actualStartTime: request.ActualStartTime,
                                       actualFinishTime: request.ActualFinishTime, 
                                       status: request.Status,
                                       updatedAt: DateTime.Now,
                                       responsiblePerson: responsiblePerson,
                                       priority: request.Priority, 
                                       problem: request.Problem, 
                                       images: listImage,
                                       materials: listMaterial,
                                       code: request.Code,
                                       note: request.Note,
                                       equipmentClass: equipmentClass,
                                       equipment: equipment,
                                       dueDate: request.DueDate,
                                       type: request.Type,
                                       inspectionReports: listInspectionReport);

            if (request.Status == EMaintenanceStatus.InProgress)
            {
                await AddWorkingTime(maintenanceResponse, cancellationToken);
            }

            if (request.Status == EMaintenanceStatus.Completed)
            {
                await UpdateEquipmentMaterial(maintenanceResponse, cancellationToken);
                await AddMaterialHistoryCard(maintenanceResponse, cancellationToken);
                await UpdateWorkingTime(maintenanceResponse, cancellationToken);
                await UpdatePerformanceIndex(maintenanceResponse, cancellationToken);
            }

            _maintenanceResponseRepository.Update(maintenanceResponse);
            return await _maintenanceResponseRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }

        private async Task UpdateEquipmentMaterial(MaintenanceResponse maintenanceResponse, CancellationToken cancellationToken)
        {
            if (maintenanceResponse.Materials is not null && maintenanceResponse.Equipment is not null && maintenanceResponse.ActualStartTime is not null && maintenanceResponse.ActualFinishTime is not null)
            {
                Dictionary<EquipmentMaterial, bool> equipmentMaterialDict = new Dictionary<EquipmentMaterial, bool>();
                
                foreach (Material material in maintenanceResponse.Materials)
                {
                    EquipmentMaterial? equipmentMaterial = maintenanceResponse.Equipment.Materials.FirstOrDefault(x => x.MaterialInfor == material.MaterialInfor);

                    if (equipmentMaterial is not null && !equipmentMaterialDict.ContainsKey(equipmentMaterial))
                    {
                        var usedTime = (decimal)TimeSpan.FromTicks(((DateTime)maintenanceResponse.ActualFinishTime - (DateTime)maintenanceResponse.ActualStartTime).Ticks).TotalMinutes;
                        equipmentMaterial.Update(materialInfor: equipmentMaterial.MaterialInfor,
                                                 fullTime: equipmentMaterial.FullTime,
                                                 usedTime: equipmentMaterial.UsedTime + usedTime,
                                                 installedTime: equipmentMaterial.InstalledTime,
                                                 updateAt: DateTime.Now);
                        _equipmentMaterialRepository.Update(equipmentMaterial);
                        await _equipmentMaterialRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

                        equipmentMaterialDict.Add(equipmentMaterial, true);
                    }
                    material.Status = Material.EMaterialStatus.InUsed;
                }
            }
        }

        private async Task AddMaterialHistoryCard(MaintenanceResponse maintenanceResponse, CancellationToken cancellationToken)
        {
            if (maintenanceResponse.Materials is not null)
            {
                Dictionary<MaterialInfor, decimal> materialInforDict = new Dictionary<MaterialInfor, decimal>();
                foreach (Material material in maintenanceResponse.Materials)
                {
                    if (materialInforDict.Count == 0)
                    {
                        materialInforDict.Add(material.MaterialInfor, 1);
                    }
                    else
                    {
                        foreach (MaterialInfor materialInfor in materialInforDict.Keys)
                        {
                            if (material.MaterialInfor == materialInfor)
                            {
                                materialInforDict[materialInfor] += 1;
                                break;
                            }
                            else
                            {
                                materialInforDict.Add(material.MaterialInfor, 1);
                                break;
                            }
                        }
                    }
                }

                foreach (MaterialInfor materialInfor in materialInforDict.Keys)
                {
                    materialInfor.OutputMaterialHistoryCard(materialInforDict[materialInfor]);
                    await _materialInforRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
                }
            }
        }

        private async Task AddWorkingTime(MaintenanceResponse maintenanceResponse, CancellationToken cancellationToken)
        {
            if (maintenanceResponse.ActualStartTime is not null && maintenanceResponse.PlannedFinish is not null && maintenanceResponse.ResponsiblePerson is not null && maintenanceResponse.Equipment is not null)
            {
                var finishTime = maintenanceResponse.ActualStartTime > maintenanceResponse.PlannedFinish ? maintenanceResponse.ActualStartTime : maintenanceResponse.PlannedFinish;
                var workingTime = new WorkingTime(Guid.NewGuid().ToString(), (DateTime)maintenanceResponse.ActualStartTime, (DateTime)finishTime, maintenanceResponse.ResponsiblePerson, maintenanceResponse.Equipment);
                _workingTimeRepository.Add(workingTime);
                await _workingTimeRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
            }
        }

        private async Task UpdateWorkingTime(MaintenanceResponse maintenanceResponse, CancellationToken cancellationToken)
        {
            if (maintenanceResponse.Equipment is not null && maintenanceResponse.ActualStartTime is not null && maintenanceResponse.ActualFinishTime is not null)
            {
                var workingTime = await _workingTimeRepository.GetByActualStartTime((DateTime)maintenanceResponse.ActualStartTime);
                if (workingTime is not null)
                {
                    workingTime.Update((DateTime)maintenanceResponse.ActualStartTime, (DateTime)maintenanceResponse.ActualFinishTime);
                    _workingTimeRepository.Update(workingTime);
                    await _workingTimeRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
                }
            }
        }

        private async Task UpdatePerformanceIndex(MaintenanceResponse maintenanceResponse, CancellationToken cancellationToken)
        {
            if (maintenanceResponse.Equipment is not null && maintenanceResponse.ActualFinishTime is not null)
            {
                var equipment = await _equipmentRepository.GetById(maintenanceResponse.Equipment.EquipmentId) ?? throw new ResourceNotFoundException(nameof(Equipment), maintenanceResponse.Equipment.EquipmentId);
                var workingTimes = await _workingTimeRepository.GetByEquipmentId(equipment.EquipmentId);

                if (workingTimes is not null)
                {
                    var actualFinishTime = (DateTime)maintenanceResponse.ActualFinishTime;

                    equipment.UsedTime = equipment.CalculateUsedTimeForEquipment(workingTimes, actualFinishTime);
                    _equipmentRepository.Update(equipment);

                    var listMaintenanceResponse = await _maintenanceResponseRepository.GetListByEquipmentId(equipment.EquipmentId);

                    if (equipment.MTBF is not null)
                    {
                        var repairFailure = equipment.CalculateRepairFailure(listMaintenanceResponse);
                        equipment.MTBF.RecentValue = repairFailure;
                        equipment.MTBF.AddHistory(actualFinishTime, repairFailure);
                        _performanceIndexRepository.Update(equipment.MTBF);
                    }

                    if (equipment.MTTF is not null)
                    {
                        var replaceFailure = equipment.CalculateReplaceFailure(listMaintenanceResponse);
                        equipment.MTTF.RecentValue = replaceFailure;
                        equipment.MTTF.AddHistory(actualFinishTime, replaceFailure);
                        _performanceIndexRepository.Update(equipment.MTTF);
                    }

                    await _equipmentRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
                    await _performanceIndexRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
                }
            }
        }
    }
}
