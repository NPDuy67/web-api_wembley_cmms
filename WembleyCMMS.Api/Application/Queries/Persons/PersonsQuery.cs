namespace WembleyCMMS.Api.Application.Queries.Persons
{
    public class PersonsQuery : PaginatedQuery, IRequest<QueryResult<PersonViewModel>>
    {
        public string? IdStartedWith { get; set; }
    }
}
