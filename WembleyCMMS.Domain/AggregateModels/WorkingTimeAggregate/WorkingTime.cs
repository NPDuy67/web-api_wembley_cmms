using WembleyCMMS.Domain.AggregateModels.EquipmentAggregate;
using WembleyCMMS.Domain.AggregateModels.PersonAggregate;

namespace WembleyCMMS.Domain.AggregateModels.WorkingTimeAggregate
{
    public class WorkingTime : Entity, IAggregateRoot
    {
        public string WorkingTimeId { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public Person ResponsiblePerson { get; set; }
        public Equipment Equipment { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private WorkingTime() { }
        public WorkingTime(string workingTimeId)
        {
            WorkingTimeId = workingTimeId;
        }

        public WorkingTime(string workingTimeId, DateTime from, DateTime to)
        {
            WorkingTimeId = workingTimeId;
            From = from;
            To = to;
        }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        public WorkingTime(string workingTimeId, DateTime from, DateTime to, Person responsiblePerson, Equipment equipment)
        {
            WorkingTimeId = workingTimeId;
            From = from;
            To = to;
            ResponsiblePerson = responsiblePerson;
            Equipment = equipment;
        }

        public void Update(DateTime from, DateTime to)
        {
            From = from;
            To = to;
        }
    }
}
