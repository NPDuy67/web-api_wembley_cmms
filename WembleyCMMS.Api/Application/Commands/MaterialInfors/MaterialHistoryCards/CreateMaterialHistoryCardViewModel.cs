using System.Runtime.Serialization;

namespace WembleyCMMS.Api.Application.Commands.MaterialInfors.MaterialHistoryCards
{
    [DataContract]
    public class CreateMaterialHistoryCardViewModel
    {
        public DateTime TimeStamp { get; set; }
        public decimal Before { get; set; }
        public decimal Input { get; set; }
        public decimal Output { get; set; }
        public decimal After { get; set; }
        public string Note { get; set; }

        public CreateMaterialHistoryCardViewModel(DateTime timeStamp, decimal before, decimal input, decimal output, decimal after, string note)
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
