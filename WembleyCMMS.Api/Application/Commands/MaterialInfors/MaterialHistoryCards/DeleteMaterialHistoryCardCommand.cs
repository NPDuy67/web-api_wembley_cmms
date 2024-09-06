namespace WembleyCMMS.Api.Application.Commands.MaterialInfors.MaterialHistoryCards
{
    public class DeleteMaterialHistoryCardCommand : IRequest<bool>
    {
        public string MaterialInforId { get; set; }
        public string MaterialHistoryCardId { get; set; }

        public DeleteMaterialHistoryCardCommand(string materialInforId, string materialHistoryCardId)
        {
            MaterialInforId = materialInforId;
            MaterialHistoryCardId = materialHistoryCardId;
        }
    }
}
