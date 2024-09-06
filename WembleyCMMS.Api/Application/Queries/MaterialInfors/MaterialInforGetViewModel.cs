using WembleyCMMS.Api.Application.Queries.MaterialInfors.Materials;
using WembleyCMMS.Domain.AggregateModels.MaterialInforAggregate;

namespace WembleyCMMS.Api.Application.Queries.MaterialInfors
{
    public class MaterialInforGetViewModel
    {
        public string? MaterialInforId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Unit { get; set; }
        public decimal CurrentQuantity { get; set; }
        public decimal MinimumQuantity { get; set; }
        public List<MaterialHistoryCard> MaterialHistoryCards { get; set; }
        public List<MaterialViewModel> Materials { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public MaterialInforGetViewModel(string? materialInforId)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            MaterialInforId = materialInforId;
        }

        public MaterialInforGetViewModel(string? materialInforId, string code, string name, string unit, decimal currentQuantity, decimal minimumQuantity, List<MaterialHistoryCard> materialHistoryCards, List<MaterialViewModel> materials)
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

        public void Update(string code, string name, string unit, decimal currentQuantity, decimal minimumQuantity, List<MaterialHistoryCard> materialHistoryCards, List<MaterialViewModel> materials)
        {
            Code = code;
            Name = name;
            Unit = unit;
            CurrentQuantity = currentQuantity;
            MinimumQuantity = minimumQuantity;
            MaterialHistoryCards = materialHistoryCards;
            Materials = materials;
        }
    }
}
