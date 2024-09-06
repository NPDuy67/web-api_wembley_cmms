namespace WembleyCMMS.Api.Application.Commands.MaterialInfors.MaterialRequests
{
    public class DeleteMaterialRequestCommand : IRequest<bool>
    {
        public string MaterialInforId { get; set; }
        public string MaterialRequestId { get; set; }

        public DeleteMaterialRequestCommand(string materialInforId, string materialRequestId)
        {
            MaterialInforId = materialInforId;
            MaterialRequestId = materialRequestId;
        }
    }
}
