using WembleyCMMS.Api.Application.Queries.MaterialInfors.MaterialHistoryCards;
using WembleyCMMS.Api.Application.Queries.MaterialInfors.Materials;
using WembleyCMMS.Domain.AggregateModels.MaterialInforAggregate;

namespace WembleyCMMS.Api.Application.Queries.MaterialInfors
{
    public class MaterialInforViewModel
    {
        public string MaterialInforId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Unit { get; set; }
        public decimal CurrentQuantity { get; set; }
        public decimal MinimumQuantity { get; set; }
        public List<MaterialHistoryCardViewModel> MaterialHistoryCards { get; set; }
        public List<MaterialViewModel> Materials { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private MaterialInforViewModel() { }

        public MaterialInforViewModel(string materialInforId, string code, string name, string unit, decimal currentQuantity, decimal minimumQuantity, List<MaterialHistoryCardViewModel> materialHistoryCards, List<MaterialViewModel> materials)
        {
            MaterialInforId = materialInforId;
            Code = code;
            Name = name;
            Unit = unit;
            CurrentQuantity = currentQuantity;
            MinimumQuantity = minimumQuantity;
            MaterialHistoryCards = materialHistoryCards;
            Materials = materials;
        }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    }
}
