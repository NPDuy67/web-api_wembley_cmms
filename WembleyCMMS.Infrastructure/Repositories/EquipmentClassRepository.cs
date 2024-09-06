using WembleyCMMS.Domain.AggregateModels.EquipmentClassAggregate;

namespace WembleyCMMS.Infrastructure.Repositories
{
    public class EquipmentClassRepository : BaseRepository, IEquipmentClassRepository
    {
        public EquipmentClassRepository(ApplicationDbContext context) : base(context) 
        { 
        }

        public EquipmentClass Add(EquipmentClass equipmentClass)
        {
            if (equipmentClass.IsTransient())
            {
                return _context.EquipmentClasses
                    .Add(equipmentClass)
                    .Entity;
            }
            else
            {
                return equipmentClass;
            }
        }

        public EquipmentClass Update(EquipmentClass equipmentClass)
        {
            return _context.EquipmentClasses
                    .Update(equipmentClass)
                    .Entity;
        }

        public async Task<EquipmentClass?> GetById(string equipmentClassId)
        {
            return await _context.EquipmentClasses
                .Include(x => x.Equipments)
                .FirstOrDefaultAsync(x => x.EquipmentClassId == equipmentClassId);
        }

        public async Task<List<EquipmentClass>?> GetAll()
        {
            return await _context.EquipmentClasses
                .AsNoTracking().ToListAsync();
        }

        public async Task Delete(string equipmentClassId)
        {
            var equipmentClass = await _context.EquipmentClasses
                .FirstOrDefaultAsync(x => x.EquipmentClassId == equipmentClassId);

            if (equipmentClass is not null)
            {
                _context.EquipmentClasses.Remove(equipmentClass);
            }
        }
    }
}
