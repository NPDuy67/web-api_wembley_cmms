﻿//using WembleyCMMS.Api.Application.Commands.ChartObjs;
//using WembleyCMMS.Api.Application.Exceptions;
//using WembleyCMMS.Domain.AggregateModels.ChartObjAggregate;

//namespace WembleyCMMS.Api.Application.Commands.ChartObjs
//{
//    public class UpdateChartObjCommandHandler : IRequestHandler<UpdateChartObjCommand, bool>
//    {
//        private readonly IChartObjRepository _chartObjRepository;

//        public UpdateChartObjCommandHandler(IChartObjRepository chartObjRepository)
//        {
//            _chartObjRepository = chartObjRepository;
//        }

//        public async Task<bool> Handle(UpdateChartObjCommand request, CancellationToken cancellationToken)
//        {
//            var chartObj = await _chartObjRepository.GetById(request.ChartObjId) ?? throw new NotFoundException();
//            chartObj.Update(request.Name, request.Value);

//            _chartObjRepository.Update(chartObj);

//            return await _chartObjRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
//        }
//    }
//}
