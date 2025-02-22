﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WembleyCMMS.Domain.AggregateModels.TimeSeriesObjectAggregate;

namespace WembleyCMMS.Domain.AggregateModels.TimeSeriesObjectAggregate
{
    public interface ITimeSeriesObjectRepository : IRepository<TimeSeriesObject>
    {
        TimeSeriesObject Add(TimeSeriesObject timeSeriesObject);
        TimeSeriesObject Update(TimeSeriesObject timeSeriesObject);
        Task<TimeSeriesObject?> GetById(string timeSeriesObject);
        Task<List<TimeSeriesObject>> GetListById(List<string> timeSeriesObjectIds);
    }
}
