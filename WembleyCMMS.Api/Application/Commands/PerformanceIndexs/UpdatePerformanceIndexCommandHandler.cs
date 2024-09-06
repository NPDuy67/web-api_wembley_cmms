using WembleyCMMS.Domain.AggregateModels.PerformanceIndexAggregate;
using WembleyCMMS.Domain.AggregateModels.TimeSeriesObjectAggregate;

namespace WembleyCMMS.Api.Application.Commands.PerformanceIndexs
{
    public class UpdatePerformanceIndexCommandHandler : IRequestHandler<UpdatePerformanceIndexCommand, bool>
    {
        private readonly IPerformanceIndexRepository _performanceIndexRepository;
        private readonly ITimeSeriesObjectRepository _timeSeriesObjectRepository;

        public UpdatePerformanceIndexCommandHandler(IPerformanceIndexRepository performanceIndexRepository, ITimeSeriesObjectRepository timeSeriesObjectRepository)
        {
            _performanceIndexRepository = performanceIndexRepository;
            _timeSeriesObjectRepository = timeSeriesObjectRepository;
        }

        public async Task<bool> Handle(UpdatePerformanceIndexCommand request, CancellationToken cancellationToken)
        {
            var listTimeSeriesObject = new List<TimeSeriesObject>();
            foreach (string temp in request.History)
            {
                var timeSeriesObject = await _timeSeriesObjectRepository.GetById(temp) ?? throw new ResourceNotFoundException(nameof(TimeSeriesObject), temp);
                listTimeSeriesObject.Add(timeSeriesObject);
            }

            var performanceIndex = await _performanceIndexRepository.GetById(request.PerformanceIndexId) ?? throw new ResourceNotFoundException(nameof(PerformanceIndex), request.PerformanceIndexId);
            performanceIndex.Update(isTracking: request.IsTracking, 
                                    recentValue: request.RecentValue,
                                    history: listTimeSeriesObject,
                                    maxLength: request.MaxLength);
            _performanceIndexRepository.Update(performanceIndex);

            return await _performanceIndexRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}
