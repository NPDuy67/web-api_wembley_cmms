using WembleyCMMS.Api.Application.Queries.EquipmentEquipmentMaterials;
using WembleyCMMS.Api.Application.Queries.EquipmentMaterials;
using WembleyCMMS.Domain.AggregateModels.EquipmentMaterialAggregate;
using WembleyCMMS.Infrastructure;

namespace WembleyCMMS.Api.Application.Queries.EquipmentMaterials
{
    public class EquipmentMaterialsQueryHandler : IRequestHandler<EquipmentMaterialsQuery, QueryResult<EquipmentMaterialViewModel>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public EquipmentMaterialsQueryHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<QueryResult<EquipmentMaterialViewModel>> Handle(EquipmentMaterialsQuery request, CancellationToken cancellationToken)
        {
            var queryable = _context.EquipmentMaterials
                .Include(x => x.Equipment)
                .Include(x => x.MaterialInfor)
                .AsNoTracking();

            if (request.IdStartedWith is not null)
            {
                queryable = queryable.Where(x => x.EquipmentMaterialId.StartsWith(request.IdStartedWith));
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
