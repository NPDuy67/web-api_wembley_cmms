using WembleyCMMS.Api.Application.Mapping.Converters;
using WembleyCMMS.Api.Application.Queries;
using WembleyCMMS.Api.Application.Queries.Causes;
using WembleyCMMS.Api.Application.Queries.ChartObjs;

//using WembleyCMMS.Api.Application.Queries.ChartObjs;
using WembleyCMMS.Api.Application.Queries.Corrections;
using WembleyCMMS.Api.Application.Queries.EquipmentClasses;
using WembleyCMMS.Api.Application.Queries.EquipmentMaterials;
using WembleyCMMS.Api.Application.Queries.Equipments;
using WembleyCMMS.Api.Application.Queries.MaintenanceRequests;
using WembleyCMMS.Api.Application.Queries.MaintenanceResponses;
using WembleyCMMS.Api.Application.Queries.MaterialInfors;
using WembleyCMMS.Api.Application.Queries.MaterialInfors.MaterialHistoryCards;
using WembleyCMMS.Api.Application.Queries.MaterialInfors.MaterialRequests;
using WembleyCMMS.Api.Application.Queries.MaterialInfors.Materials;
using WembleyCMMS.Api.Application.Queries.PerformanceIndexs;
using WembleyCMMS.Api.Application.Queries.Persons;
using WembleyCMMS.Api.Application.Queries.TimeSeriesObjects;
using WembleyCMMS.Api.Application.Queries.WorkingTimes;
using WembleyCMMS.Domain.AggregateModels.CauseAggregate;
using WembleyCMMS.Domain.AggregateModels.ChartObjAggregate;
using WembleyCMMS.Domain.AggregateModels.CorrectionAggregate;
using WembleyCMMS.Domain.AggregateModels.EquipmentClassAggregate;
using WembleyCMMS.Domain.AggregateModels.EquipmentMaterialAggregate;
using WembleyCMMS.Domain.AggregateModels.MaintenanceRequestAggregate;
using WembleyCMMS.Domain.AggregateModels.MaintenanceResponseAggregate;
using WembleyCMMS.Domain.AggregateModels.MaterialInforAggregate;
using WembleyCMMS.Domain.AggregateModels.PerformanceIndexAggregate;
using WembleyCMMS.Domain.AggregateModels.PersonAggregate;
using WembleyCMMS.Domain.AggregateModels.TimeSeriesObjectAggregate;
using WembleyCMMS.Domain.AggregateModels.WorkingTimeAggregate;

namespace WembleyCMMS.Api.Application.Mapping
{
    public class ModelToViewModelProfile : Profile
    {
        public ModelToViewModelProfile() 
        {
            MapMaintenanceRequestViewModels();

            MapEquipmentClassViewModel();
            MapEquipmentViewModels();
            MapMaterialInforViewModels();
            MapMaterialRequestViewModels();
            MapMaterialViewModels();
            MapCauseViewModels();
            MapPersonViewModels();
            MapCorrectionViewModels();
            MapMaintenanceResponseViewModels();
            MapEquipmentMaterialViewModels();
            MapTimeSeriesObjectViewModels();
            MapPerformanceIndexViewModels();
            MapWorkingTimeViewModels();
            MapMaterialHistoryCardViewModels();
        }

        public void MapEquipmentClassViewModel()
        {
            CreateMap<EquipmentClass, EquipmentClassViewModel>();
            CreateMap<QueryResult<EquipmentClass>, QueryResult<EquipmentClassViewModel>>();

            CreateMap<EquipmentClass, string>()
                .ConvertUsing<EquipmentClassToStringConverter>();
        }

        public void MapEquipmentViewModels()
        {
            CreateMap<QueryResult<Equipment>, QueryResult<EquipmentViewModel>>();
            CreateMap<Equipment, EquipmentViewModel>();
            CreateMap<Equipment, EquipmentNameViewModel>();
            CreateMap<EquipmentGetModel, EquipmentViewModel>();
            CreateMap<QueryResult<EquipmentGetModel>, QueryResult<EquipmentViewModel>>();
            CreateMap<Equipment, string>()
                .ConvertUsing<EquipmentToStringConverter>();
        }

        public void MapMaintenanceRequestViewModels()
        {
            CreateMap<QueryResult<MaintenanceRequestGetViewModel>, QueryResult<MaintenanceRequestViewModel>>();
            CreateMap<MaintenanceRequest, MaintenanceRequestViewModel>(); 
            CreateMap<MaintenanceRequestGetViewModel, MaintenanceRequestViewModel>();
        }

        public void MapChartObjViewModels()
        {
            CreateMap<QueryResult<ChartObj>, QueryResult<ChartObjViewModel>>();
            CreateMap<ChartObj, ChartObjViewModel>();
        }

        public void MapMaterialInforViewModels()
        {
            CreateMap<QueryResult<MaterialInforGetViewModel>, QueryResult<MaterialInforViewModel>>();
            CreateMap<MaterialInfor, MaterialInforViewModel>();
            CreateMap<MaterialInforGetViewModel, MaterialInforViewModel>();
        }

        public void MapMaterialRequestViewModels()
        {
            CreateMap<QueryResult<MaterialRequestGetViewModel>, QueryResult<MaterialRequestViewModel>>();
            CreateMap<MaterialRequestGetViewModel, MaterialRequestViewModel>();
        }

        public void MapMaterialViewModels()
        {
            CreateMap<QueryResult<Material>, QueryResult<MaterialViewModel>>();
            CreateMap<Material, MaterialViewModel>();
        }

        public void MapCauseViewModels()
        {
            CreateMap<QueryResult<Cause>, QueryResult<CauseViewModel>>();
            CreateMap<Cause, CauseViewModel>();
            CreateMap<Cause, string>()
                .ConvertUsing<CauseToStringConverter>(); 
            CreateMap<CauseGetViewModel, CauseViewModel>();
            CreateMap<QueryResult<CauseGetViewModel>, QueryResult<CauseViewModel>>();
        }

        public void MapPersonViewModels()
        {
            CreateMap<QueryResult<Person>, QueryResult<PersonViewModel>>();
            CreateMap<Person, PersonViewModel>();
            CreateMap<Person, string>()
                .ConvertUsing<PersonToStringConverter>();
        }

        public void MapCorrectionViewModels()
        {
            CreateMap<QueryResult<Correction>, QueryResult<CorrectionViewModel>>();
            CreateMap<Correction, CorrectionViewModel>();
            CreateMap<Correction, string>()
                .ConvertUsing<CorrectionToStringConverter>();
            CreateMap<QueryResult<CorrectionGetViewModel>, QueryResult<CorrectionViewModel>>();
            CreateMap<CorrectionGetViewModel, CorrectionViewModel>();
        }

        public void MapMaintenanceResponseViewModels()
        {
            CreateMap<QueryResult<MaintenanceResponse>, QueryResult<MaintenanceResponseViewModel>>();
            CreateMap<MaintenanceResponse, MaintenanceResponseViewModel>();
            CreateMap<MaintenanceResponseGetViewModel, MaintenanceResponseViewModel>();
            CreateMap<QueryResult<MaintenanceResponseGetViewModel>, QueryResult<MaintenanceResponseViewModel>>();
        }

        public void MapEquipmentMaterialViewModels()
        {
            CreateMap<QueryResult<EquipmentMaterial>, QueryResult<EquipmentMaterialViewModel>>();
            CreateMap<EquipmentMaterial, EquipmentMaterialViewModel>();
        }

        public void MapTimeSeriesObjectViewModels()
        {
            CreateMap<QueryResult<TimeSeriesObject>, QueryResult<TimeSeriesObjectViewModel>>();
            CreateMap<TimeSeriesObject, TimeSeriesObjectViewModel>();
        }

        public void MapPerformanceIndexViewModels()
        {
            CreateMap<QueryResult<PerformanceIndex>, QueryResult<PerformanceIndexViewModel>>();
            CreateMap<PerformanceIndex, PerformanceIndexViewModel>();
        }

        public void MapWorkingTimeViewModels()
        {
            CreateMap<QueryResult<WorkingTime>, QueryResult<WorkingTimeViewModel>>();
            CreateMap<WorkingTime, WorkingTimeViewModel>();
        }

        public void MapMaterialHistoryCardViewModels()
        {
            CreateMap<QueryResult<MaterialHistoryCard>, QueryResult<MaterialHistoryCardViewModel>>();
            CreateMap<MaterialHistoryCard, MaterialHistoryCardViewModel>();
        }
    }
}