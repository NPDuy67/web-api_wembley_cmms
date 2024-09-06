namespace WembleyCMMS.Api.Application.Queries.Charts
{
    public class ChartViewModel
    {
        public int ReactiveTotal { get; set; }
        public int ReactiveCompleted { get; set; }
        public int ReactiveCompletionRate { get; set; }
        public int PreventiveTotal { get; set; }
        public int PreventiveCompleted { get; set; }
        public int PreventiveCompletionRate { get; set; }
        public int ReactiveToPreventiveRate { get; set; }
        public int OnTimePreventive { get; set; }
        public int OverDuePreventive { get; set; }
        public int OverDuePreventiveInCompleted { get; set; }
        public List<EquipmentCauseViewModel> EquipmentCauses { get; set; }

        public ChartViewModel(int reactiveTotal, int reactiveCompleted, int reactiveCompletionRate, int preventiveTotal, int preventiveCompleted, int preventiveCompletionRate, int reactiveToPreventiveRate, int onTimePreventive, int overDuePreventive, int overDuePreventiveInCompleted, List<EquipmentCauseViewModel> equipmentCauses)
        {
            ReactiveTotal = reactiveTotal;
            ReactiveCompleted = reactiveCompleted;
            ReactiveCompletionRate = reactiveCompletionRate;
            PreventiveTotal = preventiveTotal;
            PreventiveCompleted = preventiveCompleted;
            PreventiveCompletionRate = preventiveCompletionRate;
            ReactiveToPreventiveRate = reactiveToPreventiveRate;
            OnTimePreventive = onTimePreventive;
            OverDuePreventive = overDuePreventive;
            OverDuePreventiveInCompleted = overDuePreventiveInCompleted;
            EquipmentCauses = equipmentCauses;
        }
    }
}
