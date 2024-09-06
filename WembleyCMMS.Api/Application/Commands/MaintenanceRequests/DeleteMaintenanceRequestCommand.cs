namespace WembleyCMMS.Api.Application.Commands.MaintenanceRequests
{
    public class DeleteMaintenanceRequestCommand : IRequest<bool>
    {
        public string MaintenanceRequestId { get; set; }

        public DeleteMaintenanceRequestCommand(string maintenanceRequestId)
        {
            MaintenanceRequestId = maintenanceRequestId;
        }
    }
}
