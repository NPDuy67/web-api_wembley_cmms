using WembleyCMMS.Api.Application.Queries.TimeSeriesObjects;

namespace WembleyCMMS.Api.Application.Queries.PerformanceIndexs
{
    public class PerformanceIndexViewModel
    {
        public string PerformanceIndexId { get; set; }
        public bool IsTracking { get; set; }
        public decimal RecentValue { get; set; }
        public List<TimeSeriesObjectViewModel> History { get; set; }
        public int MaxLength { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private PerformanceIndexViewModel() { }

        public PerformanceIndexViewModel(string performanceIndexId, bool isTracking, decimal recentValue, List<TimeSeriesObjectViewModel> history, int maxLength)
        {
            PerformanceIndexId = performanceIndexId;
            IsTracking = isTracking;
            RecentValue = recentValue;
            History = history;
            MaxLength = maxLength;
        }


#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    }
}
