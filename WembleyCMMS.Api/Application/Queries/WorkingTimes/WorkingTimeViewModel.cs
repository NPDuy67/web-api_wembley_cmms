namespace WembleyCMMS.Api.Application.Queries.WorkingTimes
{
    public class WorkingTimeViewModel
    {
        public string WorkingTimeId { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public string ResponsiblePerson { get; set; }
        public string Equipment { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private WorkingTimeViewModel() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        public WorkingTimeViewModel(string workingTimeId, DateTime from, DateTime to, string responsiblePerson, string equipment)
        {
            WorkingTimeId = workingTimeId;
            From = from;
            To = to;
            ResponsiblePerson = responsiblePerson;
            Equipment = equipment;
        }
    }
}
