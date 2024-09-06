using static WembleyCMMS.Domain.AggregateModels.CorrectionAggregate.Correction;
using System.Runtime.Serialization;

namespace WembleyCMMS.Api.Application.Commands.Corrections
{
    [DataContract]
    public class CreateCorrectionCommand : IRequest<bool>
    {
        public string CorrectionName { get; set; }
        public ESolutionType CorrectionType { get; set; }
        public int EstProcessTime { get; set; }
        public string Note { get; set; }

        public CreateCorrectionCommand(string correctionName, ESolutionType correctionType, int estProcessTime, string note)
        {
            CorrectionName = correctionName;
            CorrectionType = correctionType;
            EstProcessTime = estProcessTime;
            Note = note;
        }
    }
}
