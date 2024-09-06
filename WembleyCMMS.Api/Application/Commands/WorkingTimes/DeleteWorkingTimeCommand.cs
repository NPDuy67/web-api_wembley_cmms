namespace WembleyCMMS.Api.Application.Commands.WorkingTimes
{
    public class DeleteWorkingTimeCommand : IRequest<bool>
    {
        public string WorkingTimeId { get; set; }

        public DeleteWorkingTimeCommand(string workingTimeId)
        {
            WorkingTimeId = workingTimeId;
        }
    }
}
