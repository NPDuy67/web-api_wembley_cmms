using WembleyCMMS.Domain.AggregateModels.MaintenanceResponseAggregate;

namespace WembleyCMMS.Domain.AggregateModels.CorrectionAggregate
{
    public class Correction : Entity, IAggregateRoot
    {
        public string CorrectionId { get; set; }
        public string CorrectionCode { get; set; }
        public string CorrectionName { get; set; }
        public ESolutionType CorrectionType { get; set; }
        public int EstProcessTime { get; set; }
        public string Note { get; set; }
        public List<MaintenanceResponse>? MaintenanceResponses { get; set; }

        public enum ESolutionType
        {
            Repair,
            Replace
        }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private Correction() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        public Correction(string correctionId, string correctionCode, string correctionName, ESolutionType correctionType, int estProcessTime, string note)
        {
            CorrectionId = correctionId;
            CorrectionCode = correctionCode;
            CorrectionName = correctionName;
            CorrectionType = correctionType;
            EstProcessTime = estProcessTime;
            Note = note;
        }

        public void Update(string correctionCode, string correctionName, ESolutionType correctionType, int estProcessTime, string note)
        {
            CorrectionCode = correctionCode;
            CorrectionName = correctionName;
            CorrectionType = correctionType;
            EstProcessTime = estProcessTime;
            Note = note;
        }
    }
}
