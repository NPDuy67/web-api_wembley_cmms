namespace WembleyCMMS.Api.Application.Commands.MaterialInfors
{
    public class UpdateMaterialInforCommand : IRequest<bool>
    {
        public string MaterialInforId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Unit { get; set; }
        public decimal MinimumQuantity { get; set; }

        public UpdateMaterialInforCommand(string materialInforId, string code, string name, string unit, decimal minimumQuantity)
        {
            MaterialInforId = materialInforId;
            Code = code;
            Name = name;
            Unit = unit;
            MinimumQuantity = minimumQuantity;
        }
    }
}
