using WembleyCMMS.Domain.AggregateModels.CauseAggregate;

namespace WembleyCMMS.Api.Application.Commands.Causes
{
    public class DeleteCauseCommandHandler : IRequestHandler<DeleteCauseCommand, bool>
    {
        private readonly ICauseRepository _causeRepository;

        public DeleteCauseCommandHandler(ICauseRepository causeRepository)
        {
            _causeRepository = causeRepository;
        }
        public async Task<bool> Handle(DeleteCauseCommand request, CancellationToken cancellationToken)
        {
            await _causeRepository.Delete(request.CauseId);
            return await _causeRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}
