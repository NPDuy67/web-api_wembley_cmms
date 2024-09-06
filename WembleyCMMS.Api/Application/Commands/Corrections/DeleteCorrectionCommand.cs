namespace WembleyCMMS.Api.Application.Commands.Corrections
{
    public class DeleteCorrectionCommand : IRequest<bool>
    {
        public string CorrectionId { get; set; }

        public DeleteCorrectionCommand(string correctionId)
        {
            CorrectionId = correctionId;
        }
    }
}
