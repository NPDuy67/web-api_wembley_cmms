using WembleyCMMS.Domain.AggregateModels.CorrectionAggregate;

namespace WembleyCMMS.Api.Application.Commands.Corrections
{
    public class DeleteCorrectionCommandHandler : IRequestHandler<DeleteCorrectionCommand, bool>
    {
        private readonly ICorrectionRepository _correctionRepository;

        public DeleteCorrectionCommandHandler(ICorrectionRepository correctionRepository)
        {
            _correctionRepository = correctionRepository;
        }

        public async Task<bool> Handle(DeleteCorrectionCommand request, CancellationToken cancellationToken)
        {
            await _correctionRepository.Delete(request.CorrectionId);
            return await _correctionRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }   
}
