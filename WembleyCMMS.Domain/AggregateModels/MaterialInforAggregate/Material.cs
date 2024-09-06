namespace WembleyCMMS.Domain.AggregateModels.MaterialInforAggregate
{
    public class Material : Entity
    {
        public string MaterialId { get; set; }
        public MaterialInfor MaterialInfor { get; set; }
        public string Sku { get; set; }
        public EMaterialStatus? Status { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private Material() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        public Material(string materialId, MaterialInfor materialInfor, string sku, EMaterialStatus? status)
        {
            MaterialId = materialId;
            MaterialInfor = materialInfor;
            Sku = sku;
            Status = status;
        }

        public void Update(EMaterialStatus? status)
        {
            Status = status;
        }

        public enum EMaterialStatus
        {
            InUsed,
            Expired,
            Error,
            Missing,
            Available
        }
    }
}