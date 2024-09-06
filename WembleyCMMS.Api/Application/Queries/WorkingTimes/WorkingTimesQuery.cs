namespace WembleyCMMS.Api.Application.Queries.WorkingTimes
{
    public class WorkingTimesQuery : PaginatedQuery, IRequest<QueryResult<WorkingTimeViewModel>>
    {
        public string? IdStartedWith { get; set; }
        public string? PersonId { get; set; }
        public string? EquipmentId { get; set; }
    }
}
