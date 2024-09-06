using WembleyCMMS.Api.Application.Queries.EquipmentEquipmentMaterials;
using WembleyCMMS.Api.Application.Queries.EquipmentMaterials;
using WembleyCMMS.Domain.AggregateModels.EquipmentMaterialAggregate;
using WembleyCMMS.Infrastructure;

namespace WembleyCMMS.Api.Application.Queries.EquipmentMaterials
{
    public class EquipmentMaterialByIdQueryHandler : IRequestHandler<EquipmentMaterialByIdQuery, QueryResult<EquipmentMaterialViewModel>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public EquipmentMaterialByIdQueryHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<QueryResult<EquipmentMaterialViewModel>> Handle(EquipmentMaterialByIdQuery request, CancellationToken cancellationToken)
        {
            var queryable = _context.EquipmentMaterials
                .Include(x => x.Equipment)
                .Include(x => x.MaterialInfor)
                .AsNoTracking();

            if (request.EquipmentMaterialId is not null)
            {
                queryable = queryable.Where(x => x.EquipmentMaterialId == request.EquipmentMaterialId);
            }

            int totalItems = await queryable.CountAsync();

            if (request.Paginated)
            {
                queryable = queryable
                .OrderBy(x => x.EquipmentMaterialId)
                .Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize);
            }

            var equipmentMaterials = await queryable.ToListAsync();
            var queryResult = new QueryResult<EquipmentMaterial>(equipmentMaterials, totalItems);

            return _mapper.Map<QueryResult<EquipmentMaterial>, QueryResult<EquipmentMaterialViewModel>>(queryResult);
        }
    }
}
