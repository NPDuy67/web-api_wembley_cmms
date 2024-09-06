namespace WembleyCMMS.Api.Application.Commands.MaintenanceRequests.MaintenanceRequestStandards
{
    public class CreateMaintenanceRequestStandardCommand : IRequest<bool>
    {
        public string EquipmentClass { get; set; }
        public string Problem { get; set; }
        public string Requester { get; set; }
        public int EstProcessingTime { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int MaintenanceCycle { get; set; }

        public CreateMaintenanceRequestStandardCommand(string equipmentClass, string problem, string requester, int estProcessingTime, DateTime startTime, DateTime endTime, int maintenanceCycle)
        {
            EquipmentClass = equipmentClass;
            Problem = problem;
            Requester = requester;
            EstProcessingTime = estProcessingTime;
            StartTime = startTime;
            EndTime = endTime;
            MaintenanceCycle = maintenanceCycle;
        }
    }
}
