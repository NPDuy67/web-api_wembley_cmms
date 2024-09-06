using System.Runtime.Serialization;

namespace WembleyCMMS.Api.Application.Commands.PerformanceIndexs
{
    [DataContract]
    public class UpdatePerformanceIndexViewModel
    {
        public bool IsTracking { get; set; }
        public decimal RecentValue { get; set; }
        public List<string> History { get; set; }
        public int MaxLength { get; set; }

        public UpdatePerformanceIndexViewModel(bool isTracking, decimal recentValue, List<string> history, int maxLength)
        {
            IsTracking = isTracking;
            RecentValue = recentValue;
            History = history;
            MaxLength = maxLength;
        }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private UpdatePerformanceIndexViewModel() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    }
}
