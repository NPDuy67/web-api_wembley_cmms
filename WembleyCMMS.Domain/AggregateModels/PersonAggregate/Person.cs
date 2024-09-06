namespace WembleyCMMS.Domain.AggregateModels.PersonAggregate
{
    public class Person : Entity, IAggregateRoot
    {
        public string PersonId { get; set; }
        public string PersonName { get; set; }

        public Person(string personId, string personName)
        {
            PersonId = personId;
            PersonName = personName;
        }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private Person() { }

        public Person(string personId)
        {
            PersonId = personId;
        }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        public void Update(string personName)
        {
            PersonName = personName;
        }
    }
}
