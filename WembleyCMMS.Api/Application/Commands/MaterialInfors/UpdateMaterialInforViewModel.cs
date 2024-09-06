using System.Runtime.Serialization;

namespace WembleyCMMS.Api.Application.Commands.MaterialInfors
{
    [DataContract]
    public class UpdateMaterialInforViewModel
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Unit { get; set; }
        public decimal MinimumQuantity { get; set; }

        public UpdateMaterialInforViewModel(string code, string name, string unit, decimal minimumQuantity)
        {
            Code = code;
            Name = name;
            Unit = unit;
            MinimumQuantity = minimumQuantity;
        }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private UpdateMaterialInforViewModel() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    }
}
