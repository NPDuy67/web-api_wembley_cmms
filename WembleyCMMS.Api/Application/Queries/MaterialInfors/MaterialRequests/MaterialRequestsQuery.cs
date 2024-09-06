using static WembleyCMMS.Domain.AggregateModels.MaterialInforAggregate.MaterialRequest;

namespace WembleyCMMS.Api.Application.Queries.MaterialInfors.MaterialRequests
{
    public class MaterialRequestsQuery : IRequest<QueryResult<MaterialRequestViewModel>>
    {
        public string MaterialInforId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public EMaterialRequestStatus? Status { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public MaterialRequestsQuery() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        public MaterialRequestsQuery(string materialInforId, DateTime? startDate, DateTime? endDate, EMaterialRequestStatus? status)
        {
            MaterialInforId = materialInforId;
            StartDate = startDate;
            EndDate = endDate;
            Status = status;
        }
    }
}
