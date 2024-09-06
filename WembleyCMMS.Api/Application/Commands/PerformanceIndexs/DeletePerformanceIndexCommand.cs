namespace WembleyCMMS.Api.Application.Commands.PerformanceIndexs
{
    public class DeletePerformanceIndexCommand : IRequest<bool>
    {
        public string PerformanceIndexId { get; set; }

        public DeletePerformanceIndexCommand(string performanceIndexId)
        {
            PerformanceIndexId = performanceIndexId;
        }
    }
}
