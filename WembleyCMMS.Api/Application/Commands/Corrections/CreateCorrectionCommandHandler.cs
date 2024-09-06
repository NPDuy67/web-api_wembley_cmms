using WembleyCMMS.Domain.AggregateModels.CorrectionAggregate;

namespace WembleyCMMS.Api.Application.Commands.Corrections
{
    public class CreateCorrectionCommandHandler : IRequestHandler<CreateCorrectionCommand, bool>
    {
        private readonly ICorrectionRepository _correctionRepository;

        public CreateCorrectionCommandHandler(ICorrectionRepository correctionRepository)
        {
            _correctionRepository = correctionRepository;
        }

        public async Task<bool> Handle(CreateCorrectionCommand request, CancellationToken cancellationToken)
        {
            string correctionId = Guid.NewGuid().ToString();
            var listCorrection = await _correctionRepository.GetAll();
            var code = listCorrection.Count + 1;
            var correctionCode = $"COR-{code.ToString().PadLeft(4, '0')}";

            while (listCorrection.Any(x => x.CorrectionCode == correctionCode))
            {
                code = code + 1;
                correctionCode = $"COR-{code.ToString().PadLeft(4, '0')}";
            }

            var correction = new Correction(correctionId: correctionId,
                                            correctionCode: correctionCode,
                                            correctionName: request.CorrectionName,
                                            correctionType: request.CorrectionType,
                                            estProcessTime: request.EstProcessTime,
                                            note: request.Note);

            _correctionRepository.Add(correction);

            return await _correctionRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}
