//using WembleyCMMS.Api.Application.Commands.Persons;
//using WembleyCMMS.Api.Application.Exceptions;
//using WembleyCMMS.Domain.AggregateModels.InputAggregate.Common;
//using WembleyCMMS.Domain.AggregateModels.InputAggregate.ObjectInputAggregate;
//using WembleyCMMS.Domain.AggregateModels.MaintenanceRequestAggregate;
//using WembleyCMMS.Domain.AggregateModels.MaintenanceResponseAggregate;
//using WembleyCMMS.Domain.AggregateModels.NotificationAggregate;
//using WembleyCMMS.Domain.AggregateModels.PersonAggregate;
//using WembleyCMMS.Infrastructure.Repositories;
//using static WembleyCMMS.Domain.AggregateModels.EquipmentAggregate.Equipment;
//using static WembleyCMMS.Domain.AggregateModels.MaintenanceRequestAggregate.MaintenanceRequest;
//using static WembleyCMMS.Domain.AggregateModels.MaintenanceResponseAggregate.MaintenanceResponse;

//namespace WembleyCMMS.Api.Application.Commands.UpdateInputs
//{
//    public class AddUpdateInputCommandHandler : IRequestHandler<AddUpdateInputCommand, string>
//    {
//        private readonly IObjectInputRepository _objectInputRepository;
//        private readonly IMaintenanceResponseRepository _maintenanceResponseRepository;
//        private readonly IEquipmentRepository _equipmentRepository;
//        //private readonly IPersonRepository _personRepository;
//        private readonly IMaintenanceRequestRepository _maintenanceRequestRepository;
//        public AddUpdateInputCommandHandler(IObjectInputRepository objectInputRepository, 
//                                            IMaintenanceResponseRepository maintenanceResponseRepository,
//                                            IEquipmentRepository equipmentRepository,
//                                            IPersonRepository personRepository,
//                                            IMaintenanceRequestRepository maintenanceRequestRepository)
//        {
//            _objectInputRepository = objectInputRepository;
//            _maintenanceResponseRepository = maintenanceResponseRepository;
//            _equipmentRepository = equipmentRepository;
//            _personRepository = personRepository;
//            _maintenanceRequestRepository = maintenanceRequestRepository;
//        }

//        public async Task<string> Handle(AddUpdateInputCommand request, CancellationToken cancellationToken)
//        {
//            await NotificationModel.SendNotificationAsync();

//            List<MaintenanceResponse> listMaintenanceResponse = await _maintenanceResponseRepository.GetAll();
//            string result = string.Empty;
//            if (request.Confirm == true)
//            {
//                ListMaintenanceResponseReturn? listMaintenanceResponseFromTabuSearch = await _objectInputRepository.GetListMaintenanceResponseReturn();
//                if (listMaintenanceResponseFromTabuSearch != null)
//                {
//                    int i = 0;
//                    if (listMaintenanceResponseFromTabuSearch.Scheduled != null)
//                    {
//                        foreach (MaintenanceResponseGetReturn maintenanceResponseGetReturn in listMaintenanceResponseFromTabuSearch.Scheduled)
//                        {
//                            var code = $"MRES-23{(listMaintenanceResponse.Count + 1 + i).ToString().PadLeft(4, '0')}";
//                            //maintenanceResponse.Code = code;
//                            EMaintenanceObject maintenanceObject;
//                            Enum.TryParse<EMaintenanceObject>(maintenanceResponseGetReturn.MaintenanceObject, out maintenanceObject);

//                            EMaintenanceStatus status;
//                            Enum.TryParse<EMaintenanceStatus>(maintenanceResponseGetReturn.Status, out status);

//                            EMaintenanceType type;
//                            Enum.TryParse<EMaintenanceType>(maintenanceResponseGetReturn.Type, out type);

//                            Equipment? equipment = null;
//                            if (maintenanceObject == MaintenanceResponse.EMaintenanceObject.equipment)
//                            {
//                                equipment = await _equipmentRepository.GetById(maintenanceResponseGetReturn.Equipment.EquipmentId) ?? throw new NotFoundException();
//                            }
//                            var 
//                            var responsiblePerson = await _personRepository.GetById(maintenanceResponseGetReturn.ResponsiblePerson.PersonId) ?? throw new NotFoundException();
//                            var requestId = "g69b8b78-6677-4e3c-aef3-d0c5e928e2a3";
//                            var maintenanceRequest = await _maintenanceRequestRepository.GetById(requestId) ?? throw new NotFoundException();

//                            var maintenanceResponse = new MaintenanceResponse(maintenanceResponseId: maintenanceResponseGetReturn.MaintenanceResponseId,
//                                                                              cause: null,
//                                                                              correction: null,
//                                                                              plannedStart: maintenanceResponseGetReturn.PlannedStart,
//                                                                              plannedFinish: maintenanceResponseGetReturn.PlannedFinish,
//                                                                              estProcessTime: maintenanceResponseGetReturn.EstProcessTime,
//                                                                              actualStartTime: maintenanceResponseGetReturn.ActualStartTime,
//                                                                              actualFinishTime: maintenanceResponseGetReturn.ActualFinishTime,
//                                                                              status: status,
//                                                                              createdAt: DateTime.UtcNow,
//                                                                              updatedAt: DateTime.UtcNow,
//                                                                              responsiblePerson: responsiblePerson,
//                                                                              priority: maintenanceResponseGetReturn.Priority,
//                                                                              problem: maintenanceResponseGetReturn.Problem,
//                                                                              images: null,
//                                                                              materials: null,
//                                                                              code: code,
//                                                                              note: maintenanceResponseGetReturn.Note,
//                                                                              request: maintenanceRequest,
//                                                                              equipmentClass: 
//                                                                              equipment: equipment,
//                                                                              dueDate: maintenanceResponseGetReturn.DueDate,
//                                                                              type: type);

//                            _maintenanceResponseRepository.Add(maintenanceResponse);
//                            await _maintenanceResponseRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
//                            i++;
//                        }
//                    }

//                    if (listMaintenanceResponseFromTabuSearch.Rejected != null)
//                    {
//                        foreach (MaintenanceResponseGetReturn maintenanceResponseGetReturn in listMaintenanceResponseFromTabuSearch.Rejected)
//                        {
//                            var code = $"MRES-23{(listMaintenanceResponse.Count + 1 + i).ToString().PadLeft(4, '0')}";
//                            EMaintenanceObject maintenanceObject;
//                            Enum.TryParse<EMaintenanceObject>(maintenanceResponseGetReturn.MaintenanceObject, out maintenanceObject);

//                            EMaintenanceStatus status;
//                            Enum.TryParse<EMaintenanceStatus>(maintenanceResponseGetReturn.Status, out status);

//                            EMaintenanceType type;
//                            Enum.TryParse<EMaintenanceType>(maintenanceResponseGetReturn.Type, out type);

//                            Equipment? equipment = null;
//                            if (maintenanceObject == MaintenanceResponse.EMaintenanceObject.equipment)
//                            {
//                                equipment = await _equipmentRepository.GetById(maintenanceResponseGetReturn.Equipment.EquipmentId) ?? throw new NotFoundException();
//                            }
//                            var responsiblePerson = await _personRepository.GetById(maintenanceResponseGetReturn.ResponsiblePerson.PersonId) ?? throw new NotFoundException();
//                            var requestId = "g69b8b78-6677-4e3c-aef3-d0c5e928e2a3";
//                            var maintenanceRequest = await _maintenanceRequestRepository.GetById(requestId) ?? throw new NotFoundException();

//                            var maintenanceResponse = new MaintenanceResponse(maintenanceResponseId: maintenanceResponseGetReturn.MaintenanceResponseId,
//                                                                              cause: maintenanceResponseGetReturn.Cause,
//                                                                              correction: maintenanceResponseGetReturn.Correction,
//                                                                              plannedStart: maintenanceResponseGetReturn.PlannedStart,
//                                                                              plannedFinish: maintenanceResponseGetReturn.PlannedFinish,
//                                                                              estProcessTime: maintenanceResponseGetReturn.EstProcessTime,
//                                                                              actualStartTime: maintenanceResponseGetReturn.ActualStartTime,
//                                                                              actualFinishTime: maintenanceResponseGetReturn.ActualFinishTime,
//                                                                              status: status,
//                                                                              createdAt: DateTime.UtcNow,
//                                                                              updatedAt: DateTime.UtcNow,
//                                                                              responsiblePerson: maintenanceResponseGetReturn.ResponsiblePerson,
//                                                                              priority: maintenanceResponseGetReturn.Priority,
//                                                                              problem: maintenanceResponseGetReturn.Problem,
//                                                                              images: null,
//                                                                              sounds: null,
//                                                                              materials: null,
//                                                                              code: code,
//                                                                              note: maintenanceResponseGetReturn.Note,
//                                                                              request: maintenanceRequest,
//                                                                              equipment: maintenanceResponseGetReturn.Equipment,
//                                                                              dueDate: maintenanceResponseGetReturn.DueDate,
//                                                                              type: type);
//                            _maintenanceResponseRepository.Add(maintenanceResponse);
//                            await _maintenanceResponseRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
//                            i++;
//                        }
//                    }

//                    result = "Update Database success";
//                }
//                else
//                {
//                    result = "Not Found";
//                }
//            }

//            return await Task.FromResult(result);
//        }
//    }
//}
