namespace WembleyCMMS.Api.Application.Queries.ChartObjs
{
    public class ChartObjViewModel
    {
        public string Name { get; set; }
        public decimal Value { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private ChartObjViewModel() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        public ChartObjViewModel(string chartObjId, string name, decimal value)
        {
            Name = name;
            Value = value;
        }
    }
}
