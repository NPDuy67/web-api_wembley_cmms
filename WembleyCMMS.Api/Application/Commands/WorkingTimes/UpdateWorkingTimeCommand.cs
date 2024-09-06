using System.Runtime.Serialization;

namespace WembleyCMMS.Api.Application.Commands.WorkingTimes
{
    public class UpdateWorkingTimeCommand : IRequest<bool>
    {
        public string WorkingTimeId { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }

        public UpdateWorkingTimeCommand(string workingTimeId, DateTime from, DateTime to)
        {
            WorkingTimeId = workingTimeId;
            From = from;
            To = to;
        }
    }
}
