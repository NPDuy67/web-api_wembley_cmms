using WembleyCMMS.Domain.AggregateModels.EquipmentAggregate;
using WembleyCMMS.Domain.AggregateModels.MaterialInforAggregate;
using WembleyCMMS.Domain.AggregateModels.WorkingTimeAggregate;

namespace WembleyCMMS.Domain.AggregateModels.EquipmentMaterialAggregate
{
    public class EquipmentMaterial : Entity, IAggregateRoot
    {
        public string EquipmentMaterialId { get; set; }
        public Equipment Equipment { get; set; }
        public MaterialInfor MaterialInfor { get; set; }
        public decimal FullTime { get; set; }
        public decimal UsedTime { get; set; }
        public DateTime InstalledTime { get; set; }
        public DateTime UpdatedAt { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        public EquipmentMaterial(string equipmentMaterialId)
        {
            EquipmentMaterialId = equipmentMaterialId;
        }

        private EquipmentMaterial() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        public EquipmentMaterial(string equipmentMaterialId, Equipment equipment, MaterialInfor materialInfor, decimal fullTime, decimal usedTime, DateTime installedTime, DateTime updateAt)
        {
            EquipmentMaterialId = equipmentMaterialId;
            Equipment = equipment;
            MaterialInfor = materialInfor;
            FullTime = fullTime;
            UsedTime = usedTime;
            InstalledTime = installedTime;
            UpdatedAt = updateAt;
        }

        public void Update(MaterialInfor? materialInfor, decimal fullTime, decimal usedTime, DateTime installedTime, DateTime updateAt)
        {
            MaterialInfor = materialInfor ?? MaterialInfor;
            FullTime = fullTime;
            UsedTime = usedTime;
            InstalledTime = installedTime;
            UpdatedAt = updateAt;
        }

        public decimal CalculateUsedTimeForEquipmentMaterial(List<WorkingTime> workingTimes, DateTime thisTime)
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
    }
}
