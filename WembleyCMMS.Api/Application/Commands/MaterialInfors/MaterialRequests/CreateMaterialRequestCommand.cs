using static WembleyCMMS.Domain.AggregateModels.MaterialInforAggregate.MaterialRequest;

namespace WembleyCMMS.Api.Application.Commands.MaterialInfors.MaterialRequests
{
    public class CreateMaterialRequestCommand : IRequest<bool>
    {
        public string MaterialInforId { get; set; }
        public decimal AdditionalNumber { get; set; }
        public decimal ExpectedNumber { get; set; }
        public DateTime ExpectedDate { get; set; }

        public CreateMaterialRequestCommand(string materialInforId, decimal additionalNumber, decimal expectedNumber, DateTime expectedDate)
        {
            MaterialInforId = materialInforId;
            AdditionalNumber = additionalNumber;
            ExpectedNumber = expectedNumber;
            ExpectedDate = expectedDate;
        }
    }
}
