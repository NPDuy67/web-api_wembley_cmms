namespace WembleyCMMS.Api.Application.Commands.Causes
{
    public class DeleteCauseCommand : IRequest<bool>
    {
        public string CauseId { get; set; }

        public DeleteCauseCommand(string causeId)
        {
            CauseId = causeId;
        }
    }
}
