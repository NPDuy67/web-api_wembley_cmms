namespace WembleyCMMS.Domain.AggregateModels.MaterialInforAggregate
{
    public class MaterialHistoryCard : Entity
    {
        public string MaterialHistoryCardId { get; set; }
        public DateTime TimeStamp { get; set; }
        public decimal Before { get; set; }
        public decimal Input { get; set; }
        public decimal Output { get; set; }
        public decimal After { get; set; }
        public string Note { get; set; }

        public MaterialHistoryCard(string materialHistoryCardId, DateTime timeStamp, decimal before, decimal input, decimal output, decimal after, string note)
        {
            MaterialHistoryCardId = materialHistoryCardId;
            TimeStamp = timeStamp;
            Before = before;
            Input = input;
            Output = output;
            After = after;
            Note = note;
        }

        public void Update(DateTime timeStamp, decimal before, decimal input, decimal output, decimal after, string note)
        {
            TimeStamp = timeStamp;
            Before = before;
            Input = input;
            Output = output;
            After = after;
            Note = note;
        }
    }
}
