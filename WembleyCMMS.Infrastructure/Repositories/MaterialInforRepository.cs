using System.Xml.Schema;
using WembleyCMMS.Domain.AggregateModels.MaterialInforAggregate;
using WembleyCMMS.Infrastructure.Exceptions;

namespace WembleyCMMS.Infrastructure.Repositories
{
    public class MaterialInforRepository : BaseRepository, IMaterialInforRepository
    {
        public MaterialInforRepository(ApplicationDbContext context) : base(context)
        {
        }

        public MaterialInfor Add(MaterialInfor materialInfor)
        {
            if (materialInfor.IsTransient())
            {
                return _context.MaterialInfors
                    .Add(materialInfor)
                    .Entity;
            }
            else
            {
                return materialInfor;
            }
        }

        public MaterialInfor Update(MaterialInfor materialInfor)
        {
            return _context.MaterialInfors
                    .Update(materialInfor)
                    .Entity;
        }

        public async Task<MaterialInfor?> GetById(string materialInforId)
        {
            return await _context.MaterialInfors
                .Include(x => x.MaterialHistoryCards)
                .Include(x => x.Materials)
                .Include(x => x.MaterialRequests)
                .FirstOrDefaultAsync(x => x.MaterialInforId == materialInforId);
        }

        public async Task<Material?> GetMaterialById(string materialId)
        {
            var materialInfors = await _context.MaterialInfors
                .Include(x => x.Materials)
                .ToListAsync();

            return materialInfors.SelectMany(x => x.Materials).FirstOrDefault(x => x.MaterialId == materialId);
        }
        
        public async Task<List<MaterialRequest>> GetMaterialRequestByCode(string code)
        {
            var materialInfor = await _context.MaterialInfors
                .Include(x => x.MaterialRequests)
                .FirstOrDefaultAsync(x => x.Code == code) ?? throw new EntityNotFoundException(nameof(MaterialRequest), code);
   
            return materialInfor.MaterialRequests.ToList();
        }

        public async Task<List<MaterialInfor>> GetAll()
        {
            return await _context.MaterialInfors
                .Include(x => x.MaterialHistoryCards)
                .Include(x => x.Materials)
                .Include(x => x.MaterialRequests)
                .AsNoTracking().ToListAsync();
        }

        public async Task Delete(string materialInforId)
        {
            var materialInfor = await _context.MaterialInfors
                .FirstOrDefaultAsync(x => x.MaterialInforId == materialInforId);

            if (materialInfor is not null)
            {
                _context.MaterialInfors.Remove(materialInfor);
            }
        }
    }
}
