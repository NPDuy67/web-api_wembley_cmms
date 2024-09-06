namespace WembleyCMMS.Api.Application.Queries.Charts
{
    public enum ETimeInterval
    {
        Day,
        Month,
        Year
    }

    public class ChartsQuery : IRequest<ChartViewModel>
    {
        public ETimeInterval? TimeInterval { get; set; }
    }
}
