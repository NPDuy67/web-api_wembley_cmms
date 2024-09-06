namespace WembleyCMMS.Api.Application.Commands.MaterialInfors.Materials
{
    public class DeleteMaterialCommand : IRequest<bool>
    {
        public string MaterialInforId { get; set; }
        public string MaterialId { get; set; }

        public DeleteMaterialCommand(string materialInforId, string materialId)
        {
            MaterialInforId = materialInforId;
            MaterialId = materialId;
        }
    }
}
