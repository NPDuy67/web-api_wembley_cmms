using WembleyCMMS.Api.Application.Commands.PerformanceIndexs;
using WembleyCMMS.Api.Application.Exceptions;
using WembleyCMMS.Domain.AggregateModels.TimeSeriesObjectAggregate;
using WembleyCMMS.Domain.AggregateModels.PerformanceIndexAggregate;

namespace WembleyCMMS.Api.Application.Commands.PerformanceIndexs
{
    public class CreatePerformanceIndexCommandHandler : IRequestHandler<CreatePerformanceIndexCommand, bool>
    {
        private readonly IPerformanceIndexRepository _performanceIndexRepository;
        private readonly ITimeSeriesObjectRepository _timeSeriesObjectRepository;

        public CreatePerformanceIndexCommandHandler(IPerformanceIndexRepository performanceIndexRepository, ITimeSeriesObjectRepository timeSeriesObjectRepository)
        {
            _performanceIndexRepository = performanceIndexRepository;
            _timeSeriesObjectRepository = timeSeriesObjectRepository;
        }

        public async Task<bool> Handle(CreatePerformanceIndexCommand request, CancellationToken cancellationToken)
        {
            var listTimeSeriesObject = new List<TimeSeriesObject>();
            foreach (string temp in request.History)
            {
                var timeSeriesObject = await _timeSeriesObjectRepository.GetById(temp) ?? throw new ResourceNotFoundException(nameof(TimeSeriesObject), temp);
                listTimeSeriesObject.Add(timeSeriesObject);
            }

            var performanceIndexId = Guid.NewGuid().ToString();
            var performanceIndex = new PerformanceIndex(performanceIndexId: performanceIndexId, 
                                                        isTracking: request.IsTracking, 
                                                        recentValue: request.RecentValue, 
                                                        history: listTimeSeriesObject, 
                                                        maxLength: request.MaxLength);
            _performanceIndexRepository.Add(performanceIndex);

            return await _performanceIndexRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}
