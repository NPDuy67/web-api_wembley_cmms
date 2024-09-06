using System.Runtime.Serialization;

namespace WembleyCMMS.Api.Application.Commands.WorkingTimes
{
    [DataContract]
    public class UpdateWorkingTimeViewModel
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; }

        public UpdateWorkingTimeViewModel(DateTime from, DateTime to)
        {
            From = from;
            To = to;
        }

        private UpdateWorkingTimeViewModel() { }
    }
}
