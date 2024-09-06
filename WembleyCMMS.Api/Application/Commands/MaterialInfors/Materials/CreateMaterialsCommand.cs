using System.Runtime.Serialization;

namespace WembleyCMMS.Api.Application.Commands.MaterialInfors.Materials
{
    [DataContract]
    public class CreateMaterialsCommand : IRequest<bool>
    {
        public List<CreateMaterialsViewModel> Materials { get; set; }

        public CreateMaterialsCommand(List<CreateMaterialsViewModel> materials)
        {
            Materials = materials;
        }
    }
}
