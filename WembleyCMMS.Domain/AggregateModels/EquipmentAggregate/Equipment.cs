using WembleyCMMS.Domain.AggregateModels.PerformanceIndexAggregate;
using WembleyCMMS.Domain.AggregateModels.EquipmentMaterialAggregate;
using WembleyCMMS.Domain.AggregateModels.CorrectionAggregate;
using WembleyCMMS.Domain.AggregateModels.EquipmentClassAggregate;
using WembleyCMMS.Domain.AggregateModels.WorkingTimeAggregate;
using WembleyCMMS.Domain.AggregateModels.MaintenanceResponseAggregate;
using static WembleyCMMS.Domain.AggregateModels.CorrectionAggregate.Correction;

namespace WembleyCMMS.Domain.AggregateModels.EquipmentAggregate
{
    public class Equipment : Entity, IAggregateRoot
    {
        public string EquipmentId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string? ScheduleWorkingTimes { get; set; }
        public EquipmentClass EquipmentClass { get; set; }
        public PerformanceIndex MTBF { get; set; }
        public PerformanceIndex MTTF { get; set; }
        public PerformanceIndex OEE { get; set; }
        public decimal UsedTime { get; set; }
        public DateTime UpdatedAt { get; set; }
        public EMaintenanceStatus? Status { get; set; }
        public List<EquipmentMaterial> Materials { get; set; }

        public enum EMaintenanceStatus
        {
            Assigned,
            InProgress,
            Review,
            Completed
        }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private Equipment() { }

        public Equipment(string equipmentId)
        {
            EquipmentId = equipmentId;
        }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        public Equipment(string equipmentId, string code, string name, string? scheduleWorkingTimes, EquipmentClass equipmentClass, PerformanceIndex mTBF, PerformanceIndex mTTF, PerformanceIndex oEE, DateTime updatedAt)
        {
            EquipmentId = equipmentId;
            Code = code;
            Name = name;
            ScheduleWorkingTimes = scheduleWorkingTimes;
            EquipmentClass = equipmentClass;
            MTBF = mTBF;
            MTTF = mTTF;
            OEE = oEE;
            UpdatedAt = updatedAt;
            Status = EMaintenanceStatus.Assigned;
            Materials = new List<EquipmentMaterial>();
        }

        public void Update(string? code, string? name, EquipmentClass equipmentClass, DateTime updatedAt)
        {
            Code = code ?? Code;
            Name = name ?? Name;

            EquipmentClass = equipmentClass;
            UpdatedAt = updatedAt;
        }

        public decimal CalculateUsedTimeForEquipment(List<WorkingTime> workingTimes, DateTime thisTime)
        {
            decimal usedTime = 0;
            foreach (WorkingTime workingTime in workingTimes)
            {
                if ((workingTime.From <= thisTime) && (workingTime.To <= thisTime))
                {
                    usedTime += (decimal)TimeSpan.FromTicks((workingTime.To - workingTime.From).Ticks).TotalMinutes;
                }
                else if ((workingTime.From <= thisTime) && (workingTime.To > thisTime))
                {
                    usedTime += (decimal)TimeSpan.FromTicks((thisTime - workingTime.From).Ticks).TotalMinutes;
                }
            }

            return usedTime;
        }

        public decimal CalculateReplaceFailure(List<MaintenanceResponse> recentMaintenanceResponse)
        {
            int numberWorkReplace = recentMaintenanceResponse
                .SelectMany(response => response.Correction)
                .Count(correction => correction.CorrectionType == ESolutionType.Replace);

            return numberWorkReplace == 0 ? UsedTime : UsedTime / numberWorkReplace;
        }

        public decimal CalculateRepairFailure(List<MaintenanceResponse> recentMaintenanceResponse)
        {
            int numberWorkRepair = recentMaintenanceResponse
                .SelectMany(response => response.Correction)
                .Count(correction => correction.CorrectionType == ESolutionType.Repair);

            return numberWorkRepair == 0 ? UsedTime : UsedTime / numberWorkRepair;
        }
    }
}
