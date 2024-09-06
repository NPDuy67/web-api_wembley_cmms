namespace WembleyCMMS.Api.Application.Commands.Equipments
{
    public class DeleteEquipmentCommandHandler : IRequestHandler<DeleteEquipmentCommand, bool>
    {
        private readonly IEquipmentRepository _equipmentRepository;

        public DeleteEquipmentCommandHandler(IEquipmentRepository equipmentRepository)
        {
            _equipmentRepository = equipmentRepository;
        }

        public async Task<bool> Handle(DeleteEquipmentCommand request, CancellationToken cancellationToken)
        {
            await _equipmentRepository.Delete(request.EquipmentId);
            return await _equipmentRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}
