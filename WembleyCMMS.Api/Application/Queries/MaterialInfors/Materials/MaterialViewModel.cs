namespace WembleyCMMS.Api.Application.Queries.MaterialInfors.Materials
{
    public class MaterialViewModel
    {
        public string MaterialId { get; set; }
        public string Sku { get; set; }
        public string Status { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public MaterialViewModel(string materialId)
        {
            MaterialId = materialId;
        }
        private MaterialViewModel() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        public MaterialViewModel(string materialId, string sku, string status)
        {
            MaterialId = materialId;
            Sku = sku;
            Status = status;
        }
    }
}
