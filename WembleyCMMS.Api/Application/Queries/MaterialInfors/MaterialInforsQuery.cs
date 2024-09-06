namespace WembleyCMMS.Api.Application.Queries.MaterialInfors
{
    public class MaterialInforsQuery : PaginatedQuery, IRequest<QueryResult<MaterialInforViewModel>>
    {
        public string? IdStartedWith { get; set; }
    }
}
