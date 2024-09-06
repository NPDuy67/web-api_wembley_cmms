using WembleyCMMS.Domain.AggregateModels.PerformanceIndexAggregate;

namespace WembleyCMMS.Api.Application.Commands.PerformanceIndexs
{
    public class DeletePerformanceIndexCommandHandler : IRequestHandler<DeletePerformanceIndexCommand, bool>
    {
        private readonly IPerformanceIndexRepository _performanceIndexRepository;

        public DeletePerformanceIndexCommandHandler(IPerformanceIndexRepository performanceIndexRepository)
        {
            _performanceIndexRepository = performanceIndexRepository;
        }

        public async Task<bool> Handle(DeletePerformanceIndexCommand request, CancellationToken cancellationToken)
        {
            await _performanceIndexRepository.Delete(request.PerformanceIndexId);
            return await _performanceIndexRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}
