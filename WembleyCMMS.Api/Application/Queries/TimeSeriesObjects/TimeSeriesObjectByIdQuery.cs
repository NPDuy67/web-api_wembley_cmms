﻿using WembleyCMMS.Api.Application.Queries.TimeSeriesObjects;

namespace WembleyCMMS.Api.Application.Queries.TimeSeriesObjects
{
    public class TimeSeriesObjectByIdQuery : PaginatedQuery, IRequest<QueryResult<TimeSeriesObjectViewModel>>
    {
        public string? TimeSeriesObjectId { get; set; }

        public TimeSeriesObjectByIdQuery(string? soundId)
        {
            TimeSeriesObjectId = soundId;
        }
    }
}
