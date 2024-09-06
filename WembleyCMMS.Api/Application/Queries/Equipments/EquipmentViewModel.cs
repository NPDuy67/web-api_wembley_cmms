using WembleyCMMS.Api.Application.Queries.PerformanceIndexs;
using WembleyCMMS.Api.Application.Queries.EquipmentMaterials;
using WembleyCMMS.Domain.AggregateModels.ChartObjAggregate;

namespace WembleyCMMS.Api.Application.Queries.Equipments
{
    public class EquipmentViewModel
    {
        public string EquipmentId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string EquipmentClass { get; set; }
        public PerformanceIndexViewModel MTBF { get; set; }
        public PerformanceIndexViewModel MTTF { get; set; }
        public PerformanceIndexViewModel OEE { get; set; }
        public string Status { get; set; }
        public decimal UsedTime { get; set; }
        public List<ChartObj> Errors { get; set; }
        public List<EquipmentMaterialViewModel> Materials { get; set; }
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        private EquipmentViewModel() { }

        public EquipmentViewModel(string equipmentId, string code, string name, string equipmentClass, PerformanceIndexViewModel mTBF, PerformanceIndexViewModel mTTF, PerformanceIndexViewModel oEE, string status, decimal usedTime, List<ChartObj> errors, List<EquipmentMaterialViewModel> material)
        {
            EquipmentId = equipmentId;
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
