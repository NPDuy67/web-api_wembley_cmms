namespace WembleyCMMS.Api.Application.Commands.MaterialInfors
{
    public class DeleteMaterialInforCommand : IRequest<bool>
    {
        public string MaterialInforId { get; set; }

        public DeleteMaterialInforCommand(string materialInforId)
        {
            MaterialInforId = materialInforId;
        }
    }
}
