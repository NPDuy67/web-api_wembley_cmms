using WembleyCMMS.Domain.AggregateModels.WorkingTimeAggregate;

namespace WembleyCMMS.Api.Application.Commands.WorkingTimes
{
    public class UpdateWorkingTimeCommandHandler : IRequestHandler<UpdateWorkingTimeCommand, bool>
    {
        private readonly IWorkingTimeRepository _workingTimeRepository;

        public UpdateWorkingTimeCommandHandler(IWorkingTimeRepository workingTimeRepository)
        {
            _workingTimeRepository = workingTimeRepository;
        }

        public async Task<bool> Handle(UpdateWorkingTimeCommand request, CancellationToken cancellationToken)
        {
            var workingTime = await _workingTimeRepository.GetById(request.WorkingTimeId) ?? throw new ResourceNotFoundException(nameof(WorkingTime), request.WorkingTimeId);
            workingTime.Update(request.From, request.To);
            _workingTimeRepository.Update(workingTime);

            return await _workingTimeRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}
