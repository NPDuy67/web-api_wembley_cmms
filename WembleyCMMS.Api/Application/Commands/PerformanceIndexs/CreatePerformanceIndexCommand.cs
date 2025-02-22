﻿using System.Runtime.Serialization;

namespace WembleyCMMS.Api.Application.Commands.PerformanceIndexs
{
    [DataContract]
    public class CreatePerformanceIndexCommand : IRequest<bool>
    {
        public bool IsTracking { get; set; }
        public decimal RecentValue { get; set; }
        public List<string> History { get; set; }
        public int MaxLength { get; set; }

        public CreatePerformanceIndexCommand(bool isTracking, decimal recentValue, List<string> history, int maxLength)
        {
            IsTracking = isTracking;
            RecentValue = recentValue;
            History = history;
            MaxLength = maxLength;
        }
    }
}
