using WembleyCMMS.Api.Application.Queries.PerformanceIndexs;

namespace WembleyCMMS.Api.Application.Queries.PerformanceIndexs
{
    public class PerformanceIndexByIdQuery : PaginatedQuery, IRequest<QueryResult<PerformanceIndexViewModel>>
    {
        public string PerformanceIndexId { get; set; }

        public PerformanceIndexByIdQuery(string equipmentId)
        {
            PerformanceIndexId = equipmentId;
        }
    }
}
