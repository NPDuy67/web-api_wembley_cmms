namespace WembleyCMMS.Domain.AggregateModels.MaterialInforAggregate
{
    public interface IMaterialInforRepository : IRepository<MaterialInfor>
    {
        public MaterialInfor Add(MaterialInfor materialInfor);
        public MaterialInfor Update(MaterialInfor materialInfor);
        public Task<MaterialInfor?> GetById(string materialInforId);
        public Task<Material?> GetMaterialById(string materialId);
        public Task<List<MaterialRequest>> GetMaterialRequestByCode(string code);
        public Task<List<MaterialInfor>> GetAll();
        public Task Delete(string materialInforId);
    }
}
