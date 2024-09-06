namespace WembleyCMMS.Api.Application.Commands.MaterialInfors.MaterialHistoryCards
{
    public class UpdateMaterialHistoryCardCommand : IRequest<bool>
    {
        public string MaterialInforId { get; set; }
        public string MaterialHistoryCardId { get; set; }
        public DateTime TimeStamp { get; set; }
        public decimal Before { get; set; }
        public decimal Input { get; set; }
        public decimal Output { get; set; }
        public decimal After { get; set; }
        public string Note { get; set; }

        public UpdateMaterialHistoryCardCommand(string materialInforId, string materialHistoryCardId, DateTime timeStamp, decimal before, decimal input, decimal output, decimal after, string note)
        {
            MaterialInforId = materialInforId;
            MaterialHistoryCardId = materialHistoryCardId;
            TimeStamp = timeStamp;
            Before = before;
            Input = input;
            Output = output;
            After = after;
            Note = note;
        }
    }
}
