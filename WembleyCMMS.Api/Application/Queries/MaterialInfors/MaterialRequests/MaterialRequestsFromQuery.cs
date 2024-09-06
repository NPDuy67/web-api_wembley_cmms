using static WembleyCMMS.Domain.AggregateModels.MaterialInforAggregate.MaterialRequest;

namespace WembleyCMMS.Api.Application.Queries.MaterialInfors.MaterialRequests
{
    public class MaterialRequestsFromQuery
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public EMaterialRequestStatus? Status { get; set; }

        public MaterialRequestsFromQuery() { }

        public MaterialRequestsFromQuery(DateTime? startDate, DateTime? endDate, EMaterialRequestStatus? status)
        {
            StartDate = startDate;
            EndDate = endDate;
            Status = status;
        }
    }
}
