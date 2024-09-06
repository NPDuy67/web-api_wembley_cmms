namespace WembleyCMMS.Api.Application.Commands.MaterialInfors.Materials
{
    public class CreateMaterialCommand : IRequest<bool>
    {
        public string Sku { get; set; }
        public string MaterialInforId { get; set; }

        public CreateMaterialCommand(string sku, string materialInforId)
        {
            Sku = sku;
            MaterialInforId = materialInforId;
        }
    }
}
