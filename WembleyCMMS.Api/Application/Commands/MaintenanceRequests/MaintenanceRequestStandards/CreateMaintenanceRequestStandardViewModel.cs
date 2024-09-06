using System.Runtime.Serialization;

namespace WembleyCMMS.Api.Application.Commands.MaintenanceRequests.MaintenanceRequestStandards
{
    [DataContract]
    public class CreateMaintenanceRequestStandardViewModel
    {
        public string Problem { get; set; }
        public string Requester { get; set; }
        public int EstProcessingTime { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int MaintenanceCycle { get; set; }

        public CreateMaintenanceRequestStandardViewModel(string problem, string requester, int estProcessingTime, DateTime startTime, DateTime endTime, int maintenanceCycle)
        {
            Problem = problem;
            Requester = requester;
            EstProcessingTime = estProcessingTime;
            StartTime = startTime;
            EndTime = endTime;
            MaintenanceCycle = maintenanceCycle;
        }
    }
}
