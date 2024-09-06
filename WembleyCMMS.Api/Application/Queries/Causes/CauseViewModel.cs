namespace WembleyCMMS.Api.Application.Queries.Causes
{
    public class CauseViewModel
    {
        public string CauseId { get; set; }
        public string CauseCode { get; set; }
        public string CauseName { get; set; }
        public string EquipmentClass { get; set; }
        public string Severity { get; set; }
        public string Note { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private CauseViewModel() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        public CauseViewModel(string causeId, string causeCode, string causeName, string equipmentClass, string severity, string note)
        {
            CauseId = causeId;
            CauseCode = causeCode;
            CauseName = causeName;
            EquipmentClass = equipmentClass;
            Severity = severity;
            Note = note;
        }
    }
}
