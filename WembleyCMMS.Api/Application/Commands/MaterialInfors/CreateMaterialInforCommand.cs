using static WembleyCMMS.Domain.AggregateModels.MaterialInforAggregate.MaterialInfor;
using System.Runtime.Serialization;

namespace WembleyCMMS.Api.Application.Commands.MaterialInfors
{
    [DataContract]
    public class CreateMaterialInforCommand : IRequest<bool>
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Unit { get; set; }
        public decimal MinimumQuantity { get; set; }

        public CreateMaterialInforCommand(string code, string name, string unit, decimal minimumQuantity)
        {
            Code = code;
            Name = name;
            Unit = unit;
            MinimumQuantity = minimumQuantity;
        }
    }
}
