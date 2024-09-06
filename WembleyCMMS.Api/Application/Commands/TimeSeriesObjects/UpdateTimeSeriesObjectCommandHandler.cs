using WembleyCMMS.Api.Application.Commands.TimeSeriesObjects;
using WembleyCMMS.Api.Application.Exceptions;
using WembleyCMMS.Domain.AggregateModels.TimeSeriesObjectAggregate;

namespace WembleyCMMS.Api.Application.Commands.TimeSeriesObjects
{
    public class UpdateTimeSeriesObjectCommandHandler : IRequestHandler<UpdateTimeSeriesObjectCommand, bool>
    {
        private readonly ITimeSeriesObjectRepository _soundRepository;

        public UpdateTimeSeriesObjectCommandHandler(ITimeSeriesObjectRepository soundRepository)
        {
            _soundRepository = soundRepository;
        }

        public async Task<bool> Handle(UpdateTimeSeriesObjectCommand request, CancellationToken cancellationToken)
        {
            var sound = await _soundRepository.GetById(request.TimeSeriesObjectId) ?? throw new NotFoundException();
            sound.Update(request.Time, request.Value);
            _soundRepository.Update(sound);

            return await _soundRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}
