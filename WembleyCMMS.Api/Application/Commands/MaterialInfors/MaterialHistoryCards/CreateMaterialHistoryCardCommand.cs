namespace WembleyCMMS.Api.Application.Commands.MaterialInfors.MaterialHistoryCards
{
    public class CreateMaterialHistoryCardCommand : IRequest<bool>
    {
        public string MaterialInforId { get; set; }
        public DateTime TimeStamp { get; set; }
        public decimal Before { get; set; }
        public decimal Input { get; set; }
        public decimal Output { get; set; }
        public decimal After { get; set; }
        public string Note { get; set; }

        public CreateMaterialHistoryCardCommand(string materialInforId, DateTime timeStamp, decimal before, decimal input, decimal output, decimal after, string note)
        {
            MaterialInforId = materialInforId;
            TimeStamp = timeStamp;
            Before = before;
            Input = input;
            Output = output;
            After = after;
            Note = note;
        }
    }
}
