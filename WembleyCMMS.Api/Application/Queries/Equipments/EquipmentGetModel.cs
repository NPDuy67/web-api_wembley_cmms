using WembleyCMMS.Domain.AggregateModels.PerformanceIndexAggregate;
using WembleyCMMS.Domain.AggregateModels.EquipmentMaterialAggregate;
using WembleyCMMS.Domain.AggregateModels.EquipmentClassAggregate;
using WembleyCMMS.Domain.AggregateModels.ChartObjAggregate;

namespace WembleyCMMS.Api.Application.Queries.Equipments
{
    public class EquipmentGetModel
    {
        public string EquipmentId { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }
        public EquipmentClass EquipmentClass { get; set; }
        public PerformanceIndex? MTBF { get; set; }
        public PerformanceIndex? MTTF { get; set; }
        public PerformanceIndex? OEE { get; set; }
        public string? Status { get; set; } //Enum
        public decimal UsedTime { get; set; }
        public List<ChartObj>? Errors { get; set; }
        public List<EquipmentMaterial>? Materials { get; set; }
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        private EquipmentGetModel() { }

        public EquipmentGetModel(string equipmentId)
        {
            EquipmentId = equipmentId;
        }

        public EquipmentGetModel(string equipmentId, string? code, string? name, EquipmentClass equipmentClass, PerformanceIndex? mTBF, PerformanceIndex? mTTF, PerformanceIndex? oEE, string? status, decimal usedTime, List<ChartObj>? errors, List<EquipmentMaterial>? material) : this(equipmentId)
        {
            Code = code;
            Name = name;
            EquipmentClass = equipmentClass;
            MTBF = mTBF;
            MTTF = mTTF;
            OEE = oEE;
            Status = status;
            UsedTime = usedTime;
            Errors = errors;
            Materials = material;
        }


#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    }
}
