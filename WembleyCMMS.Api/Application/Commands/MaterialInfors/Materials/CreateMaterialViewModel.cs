using System.Runtime.Serialization;

namespace WembleyCMMS.Api.Application.Commands.MaterialInfors.Materials
{
    [DataContract]
    public class CreateMaterialViewModel
    {
        public string Sku { get; set; }

        public CreateMaterialViewModel(string sku)
        {
            Sku = sku;
        }
    }
}
