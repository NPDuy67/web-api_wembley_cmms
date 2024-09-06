using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WembleyCMMS.Domain.AggregateModels.EquipmentMaterialAggregate;
using WembleyCMMS.Domain.AggregateModels.MaintenanceResponseAggregate;

namespace WembleyCMMS.Infrastructure.Repositories
{
    public class EquipmentMaterialRepository : BaseRepository, IEquipmentMaterialRepository
    {
        public EquipmentMaterialRepository(ApplicationDbContext context) : base(context)
        {
        }

        public EquipmentMaterial Add(EquipmentMaterial equipmentMaterial)
        {
            if (equipmentMaterial.IsTransient())
            {
                return _context.EquipmentMaterials
                    .Add(equipmentMaterial)
                    .Entity;
            }
            else
            {
                return equipmentMaterial;
            }
        }

        public EquipmentMaterial Update(EquipmentMaterial equipmentMaterial)
        {
            return _context.EquipmentMaterials
                    .Update(equipmentMaterial)
                    .Entity;
        }

        public async Task<EquipmentMaterial?> GetById(string equipmentMaterialId)
        {
            return await _context.EquipmentMaterials
                .FirstOrDefaultAsync(x => x.EquipmentMaterialId == equipmentMaterialId);
        }

        public async Task<List<EquipmentMaterial>> GetListByEquipmentId(string equipmentId)
        {
            var equipment = await _context.Equipments
                .Include(x => x.Materials)
                .ThenInclude(x => x.MaterialInfor)
                .FirstOrDefaultAsync(x => x.EquipmentId == equipmentId);

            var listEquipmentMaterial = new List<EquipmentMaterial>();
            foreach (var equipmentMaterial in equipment.Materials)
            {
                var temp = await _context.EquipmentMaterials
                    .Where(x => x.EquipmentMaterialId == equipmentMaterial.EquipmentMaterialId)
                    .FirstOrDefaultAsync();
                listEquipmentMaterial.Add(temp);
            }
            return listEquipmentMaterial;
        }

        public async Task Delete(string equipmentMaterialId)
        {
            var equipmentMaterial = await _context.EquipmentMaterials
                .FirstOrDefaultAsync(x => x.EquipmentMaterialId == equipmentMaterialId);
            
            if (equipmentMaterial is not null)
            {
                _context.EquipmentMaterials.Remove(equipmentMaterial);
            }
        }
    }
}
