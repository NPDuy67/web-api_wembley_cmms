using WembleyCMMS.Domain.AggregateModels.CorrectionAggregate;

namespace WembleyCMMS.Api.Application.Commands.Corrections
{
    public class UpdateCorrectionCommandHandler : IRequestHandler<UpdateCorrectionCommand, bool>
    {
        private readonly ICorrectionRepository _correctionRepository;

        public UpdateCorrectionCommandHandler(ICorrectionRepository correctionRepository)
        {
            _correctionRepository = correctionRepository;
        }

        public async Task<bool> Handle(UpdateCorrectionCommand request, CancellationToken cancellationToken)
        {
            var correction = await _correctionRepository.GetById(request.CorrectionId) ?? throw new ResourceNotFoundException(nameof(Correction), request.CorrectionId);

            correction.Update(request.CorrectionCode, request.CorrectionName, request.CorrectionType, request.EstProcessTime, request.Note);
            _correctionRepository.Update(correction);

            return await _correctionRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}
