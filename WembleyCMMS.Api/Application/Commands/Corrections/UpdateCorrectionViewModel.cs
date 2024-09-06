using System.Runtime.Serialization;
using static WembleyCMMS.Domain.AggregateModels.CorrectionAggregate.Correction;

namespace WembleyCMMS.Api.Application.Commands.Corrections
{
    [DataContract]
    public class UpdateCorrectionViewModel
    {
        public string CorrectionCode { get; set; }
        public string CorrectionName { get; set; }
        public ESolutionType CorrectionType { get; set; }
        public int EstProcessTime { get; set; }
        public string Note { get; set; }

        public UpdateCorrectionViewModel(string correctionCode, string correctionName, ESolutionType correctionType, int estProcessTime, string note)
        {
            CorrectionCode = correctionCode;
            CorrectionName = correctionName;
            CorrectionType = correctionType;
            EstProcessTime = estProcessTime;
            Note = note;
        }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private UpdateCorrectionViewModel() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    }
}
