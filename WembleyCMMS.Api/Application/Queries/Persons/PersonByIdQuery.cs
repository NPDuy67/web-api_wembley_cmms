﻿namespace WembleyCMMS.Api.Application.Queries.Persons
{
    public class PersonByIdQuery : PaginatedQuery, IRequest<QueryResult<PersonViewModel>>
    {
        public string PersonId { get; set; }

        public PersonByIdQuery(string equipmentId)
        {
            PersonId = equipmentId;
        }
    }
}
