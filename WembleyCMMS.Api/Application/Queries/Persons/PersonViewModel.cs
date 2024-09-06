namespace WembleyCMMS.Api.Application.Queries.Persons
{
    public class PersonViewModel
    {
        public string PersonId { get; set; }
        public string PersonName { get; set; }


#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private PersonViewModel() { }

        public PersonViewModel(string personId, string personName)
        {
            PersonId = personId;
            PersonName = personName;
        }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    }
}
