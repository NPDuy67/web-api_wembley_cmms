using WembleyCMMS.Domain.AggregateModels.TimeSeriesObjectAggregate;
using WembleyCMMS.Domain.Exceptions;

namespace WembleyCMMS.Domain.AggregateModels.PerformanceIndexAggregate
{
    public class PerformanceIndex : Entity, IAggregateRoot
    {
        public string PerformanceIndexId { get; set; }
        public bool IsTracking { get; set; }
        public decimal RecentValue { get; set; }
        public List<TimeSeriesObject> History { get; set; }
        public int MaxLength { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private PerformanceIndex()
        {
        }

        public PerformanceIndex(string performanceIndexId)
        {
            PerformanceIndexId = performanceIndexId;
        }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        public PerformanceIndex(string performanceIndexId, bool isTracking, decimal recentValue, List<TimeSeriesObject> history, int maxLength)
        {
            PerformanceIndexId = performanceIndexId;
            IsTracking = isTracking;
            RecentValue = recentValue;
            History = history;
            MaxLength = maxLength;
        }

        public void Update(bool isTracking, decimal recentValue, List<TimeSeriesObject> history, int maxLength)
        {
            IsTracking = isTracking;
            RecentValue = recentValue;
            History = history;
            MaxLength = maxLength;
        }

        public void AddHistory(DateTime time, decimal value)
        {
            var timeSeriesObject = new TimeSeriesObject(Guid.NewGuid().ToString(), time, value);

            if (History.Exists(x => x.TimeSeriesObjectId == timeSeriesObject.TimeSeriesObjectId))
            {
                throw new ChildEntityDuplicationException(timeSeriesObject.TimeSeriesObjectId, timeSeriesObject, PerformanceIndexId, this);
            }

            History.Add(timeSeriesObject);
        }   
    }
}
