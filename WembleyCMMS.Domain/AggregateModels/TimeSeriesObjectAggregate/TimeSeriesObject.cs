namespace WembleyCMMS.Domain.AggregateModels.TimeSeriesObjectAggregate
{
    public class TimeSeriesObject : Entity, IAggregateRoot
    {
        public string TimeSeriesObjectId { get; set; }
        public DateTime Time { get; set; }
        public decimal Value { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private TimeSeriesObject() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        public TimeSeriesObject(string timeSeriesObjectId, DateTime time, decimal value)
        {
            TimeSeriesObjectId = timeSeriesObjectId;
            Time = time;
            Value = value;
        }

        public void Update(DateTime time, decimal value)
        {
            Time = time;
            Value = value;
        }
    }
}
