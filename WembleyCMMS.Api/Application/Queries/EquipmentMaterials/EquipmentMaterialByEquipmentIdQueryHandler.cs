using WembleyCMMS.Domain.AggregateModels.EquipmentMaterialAggregate;
using WembleyCMMS.Infrastructure;
using static WembleyCMMS.Domain.AggregateModels.MaterialInforAggregate.Material;

namespace WembleyCMMS.Api.Application.Queries.EquipmentMaterials
{
    public class EquipmentMaterialByEquipmentIdQueryHandler : IRequestHandler<EquipmentMaterialByEquipmentIdQuery, QueryResult<EquipmentMaterialViewModel>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public EquipmentMaterialByEquipmentIdQueryHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<QueryResult<EquipmentMaterialViewModel>> Handle(EquipmentMaterialByEquipmentIdQuery request, CancellationToken cancellationToken)
        {
            var queryable = _context.EquipmentMaterials
                .Include(x => x.Equipment)
                .Include(x => x.MaterialInfor)
                .ThenInclude(x => x.Materials)
                .Where(x => x.Equipment.EquipmentId == request.EquipmentId)
                .AsNoTracking();

            int totalItems = await queryable.CountAsync();

            if (request.Paginated)
            {
                queryable = queryable
                    .OrderBy(x => x.EquipmentMaterialId)
                    .Skip((request.PageIndex - 1) * request.PageSize)
                    .Take(request.PageSize);
            }

            var equipmentMaterials = await queryable.ToListAsync();

            equipmentMaterials.ForEach(x => x.MaterialInfor.Materials = x.MaterialInfor.Materials.Where(x => x.Status == EMaterialStatus.Available).ToList());
            var queryResult = new QueryResult<EquipmentMaterial>(equipmentMaterials, totalItems);

            return _mapper.Map<QueryResult<EquipmentMaterial>, QueryResult<EquipmentMaterialViewModel>>(queryResult);
        }
    }
}
