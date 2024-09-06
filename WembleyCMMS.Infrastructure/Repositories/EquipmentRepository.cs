using WembleyCMMS.Domain.AggregateModels.EquipmentAggregate;

namespace WembleyCMMS.Infrastructure.Repositories
{
    public class EquipmentRepository : BaseRepository, IEquipmentRepository
    {
        public EquipmentRepository(ApplicationDbContext context) : base(context)
        {
        }

        public Equipment Add(Equipment equipment)
        {
            if (equipment.IsTransient())
            {
                return _context.Equipments
                    .Add(equipment)
                    .Entity;
            }
            else
            {
                return equipment;
            }
        }

        public Equipment Update(Equipment equipment)
        {
            return _context.Equipments
                    .Update(equipment)
                    .Entity;
        }

        public async Task<Equipment?> GetById(string equipmentId)
        {
            return await _context.Equipments
                .Include(x => x.EquipmentClass)
                .Include(x => x.MTBF)
                .ThenInclude(x => x.History)
                .Include(x => x.MTTF)
                .ThenInclude(x => x.History)
                .Include(x => x.Materials)
                .ThenInclude(x => x.MaterialInfor)
                .FirstOrDefaultAsync(x => x.EquipmentId == equipmentId);
        }

        public async Task<Equipment?> GetByCode(string code)
        {
            return await _context.Equipments
                .Include(x => x.MTBF)
                .Include(x => x.MTTF)
                .FirstOrDefaultAsync(x => x.Code == code);
        }

        public async Task<List<Equipment>?> GetByEquipmentClassId(string equipmentClassId)
        {
            return await _context.Equipments
                .Include(x => x.EquipmentClass)
                .Include(x => x.MTBF)
                .Include(x => x.MTTF)
                .Include(x => x.Materials)
                .ThenInclude(x => x.MaterialInfor)
                .Where(x => x.EquipmentClass.EquipmentClassId == equipmentClassId)
                .ToListAsync();
        }

        public async Task<List<Equipment>?> GetAll()
        {
            return await _context.Equipments
                .AsNoTracking().ToListAsync();
        }

        public async Task Delete(string equipmentId)
        {
            var equipment = await _context.Equipments
                .FirstOrDefaultAsync(x => x.EquipmentId == equipmentId);

            if (equipment is not null)
            {
                _context.Equipments.Remove(equipment);
            }
        }
    }
}
