namespace WembleyCMMS.Domain.AggregateModels.InspectionReportAggregate
{
    public interface IInspectionReportRepository : IRepository<InspectionReport>
    {
        InspectionReport Add(InspectionReport report);
        InspectionReport Update(InspectionReport report);
        Task<InspectionReport?> GetById(string reportId);
        Task DeleteAsync(string reportId);
    }
}
