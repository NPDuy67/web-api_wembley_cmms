namespace WembleyCMMS.Api.Application.Commands.PerformanceIndexs
{
    public class UpdatePerformanceIndexCommand : IRequest<bool>
    {
        public string PerformanceIndexId { get; set; }
        public bool IsTracking { get; set; }
        public decimal RecentValue { get; set; }
        public List<string> History { get; set; }
        public int MaxLength { get; set; }

        public UpdatePerformanceIndexCommand(string performanceIndexId, bool isTracking, decimal recentValue, List<string> history, int maxLength)
        {
            PerformanceIndexId = performanceIndexId;
            IsTracking = isTracking;
            RecentValue = recentValue;
            History = history;
            MaxLength = maxLength;
        }
    }
}
