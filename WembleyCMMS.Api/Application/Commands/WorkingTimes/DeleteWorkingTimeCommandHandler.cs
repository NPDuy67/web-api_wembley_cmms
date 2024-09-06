using WembleyCMMS.Domain.AggregateModels.WorkingTimeAggregate;

namespace WembleyCMMS.Api.Application.Commands.WorkingTimes
{
    public class DeleteWorkingTimeCommandHandler : IRequestHandler<DeleteWorkingTimeCommand, bool>
    {
        private IWorkingTimeRepository _workingTimeRepository;

        public DeleteWorkingTimeCommandHandler(IWorkingTimeRepository workingTimeRepository)
        {
            _workingTimeRepository = workingTimeRepository;
        }

        public async Task<bool> Handle(DeleteWorkingTimeCommand request, CancellationToken cancellationToken)
        {
            await _workingTimeRepository.Delete(request.WorkingTimeId);
            return await _workingTimeRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}
