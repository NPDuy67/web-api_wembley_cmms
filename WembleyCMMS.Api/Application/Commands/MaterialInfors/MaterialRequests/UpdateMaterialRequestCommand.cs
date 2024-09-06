using System.Runtime.Serialization;
using static WembleyCMMS.Domain.AggregateModels.MaterialInforAggregate.MaterialRequest;

namespace WembleyCMMS.Api.Application.Commands.MaterialInfors.MaterialRequests
{
    public class UpdateMaterialRequestCommand : IRequest<bool>
    {
        public string MaterialRequestId { get; set; }
        public string MaterialInforId { get; set; }
        public decimal? CurrentNumber { get; set; }
        public decimal? AdditionalNumber { get; set; }
        public decimal? ExpectedNumber { get; set; }
        public DateTime? ExpectedDate { get; set; }
        public EMaterialRequestStatus? Status { get; set; }

        public UpdateMaterialRequestCommand(string materialRequestId, string materialInforId, decimal? currentNumber, decimal? additionalNumber, decimal? expectedNumber, DateTime? expectedDate, EMaterialRequestStatus? status)
        {
            MaterialRequestId = materialRequestId;
            MaterialInforId = materialInforId;
            CurrentNumber = currentNumber;
            AdditionalNumber = additionalNumber;
            ExpectedNumber = expectedNumber;
            ExpectedDate = expectedDate;
            Status = status;
        }
    }
}
