﻿using static WembleyCMMS.Domain.AggregateModels.CorrectionAggregate.Correction;

namespace WembleyCMMS.Api.Application.Commands.Corrections
{
    public class UpdateCorrectionCommand : IRequest<bool>
    {
        public string CorrectionId { get; set; }
        public string CorrectionCode { get; set; }
        public string CorrectionName { get; set; }
        public ESolutionType CorrectionType { get; set; }
        public int EstProcessTime { get; set; }
        public string Note { get; set; }

        public UpdateCorrectionCommand(string correctionId, string correctionCode, string correctionName, ESolutionType correctionType, int estProcessTime, string note)
        {
            CorrectionId = correctionId;
            CorrectionCode = correctionCode;
            CorrectionName = correctionName;
            CorrectionType = correctionType;
            EstProcessTime = estProcessTime;
            Note = note;
        }
    }
}
