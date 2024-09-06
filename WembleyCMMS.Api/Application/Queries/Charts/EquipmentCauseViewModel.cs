using WembleyCMMS.Domain.AggregateModels.ChartObjAggregate;

namespace WembleyCMMS.Api.Application.Queries.Charts
{
    public class EquipmentCauseViewModel
    {
        public string EquipmentId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public List<ChartObj> Errors { get; set; }

        public EquipmentCauseViewModel(string equipmentId, string code, string name, List<ChartObj> errors)
        {
            EquipmentId = equipmentId;
            Code = code;
            Name = name;
            Errors = errors;
        }
    }
}
