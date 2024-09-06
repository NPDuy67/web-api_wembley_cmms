using System.Runtime.Serialization;
using static WembleyCMMS.Domain.AggregateModels.MaterialInforAggregate.MaterialRequest;

namespace WembleyCMMS.Api.Application.Commands.MaterialInfors.MaterialRequests
{
    [DataContract]
    public class UpdateMaterialRequestViewModel
    {
        public decimal? CurrentNumber { get; set; }
        public decimal? AdditionalNumber { get; set; }
        public decimal? ExpectedNumber { get; set; }
        public DateTime? ExpectedDate { get; set; }
        public EMaterialRequestStatus? Status { get; set; }

        public UpdateMaterialRequestViewModel(decimal? currentNumber, decimal? additionalNumber, decimal? expectedNumber, DateTime? expectedDate, EMaterialRequestStatus? status)
        {
            CurrentNumber = currentNumber;
            AdditionalNumber = additionalNumber;
            ExpectedNumber = expectedNumber;
            ExpectedDate = expectedDate;
            Status = status;
        }





#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private UpdateMaterialRequestViewModel() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    }
}
