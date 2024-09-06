namespace WembleyCMMS.Api.Application.Commands.MaintenanceResponses
{
    public class DeleteMaintenanceResponseCommand : IRequest<bool>
    {
        public string MaintenanceResponseId { get; set; }

        public DeleteMaintenanceResponseCommand(string maintenanceResponseId)
        {
            MaintenanceResponseId = maintenanceResponseId;
        }
    }
}
