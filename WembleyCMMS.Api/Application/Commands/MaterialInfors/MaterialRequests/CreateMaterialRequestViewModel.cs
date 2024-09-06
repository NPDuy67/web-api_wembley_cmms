using System.Runtime.Serialization;

namespace WembleyCMMS.Api.Application.Commands.MaterialInfors.MaterialRequests
{
    [DataContract]
    public class CreateMaterialRequestViewModel
    {
        public decimal AdditionalNumber { get; set; }
        public decimal ExpectedNumber { get; set; }
        public DateTime ExpectedDate { get; set; }

        public CreateMaterialRequestViewModel(decimal additionalNumber, decimal expectedNumber, DateTime expectedDate)
        {
            AdditionalNumber = additionalNumber;
            ExpectedNumber = expectedNumber;
            ExpectedDate = expectedDate;
        }
    }
}
