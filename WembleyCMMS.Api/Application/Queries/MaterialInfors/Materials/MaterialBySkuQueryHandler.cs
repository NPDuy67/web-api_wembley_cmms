using WembleyCMMS.Domain.AggregateModels.MaterialInforAggregate;
using WembleyCMMS.Infrastructure;

namespace WembleyCMMS.Api.Application.Queries.MaterialInfors.Materials
{
    public class MaterialBySkuQueryHandler : IRequestHandler<MaterialBySkuQuery, QueryResult<MaterialViewModel>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public MaterialBySkuQueryHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<QueryResult<MaterialViewModel>> Handle(MaterialBySkuQuery request, CancellationToken cancellationToken)
        {
            var materialInfors = await _context.MaterialInfors
                .Include(x => x.Materials)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.MaterialInforId == request.MaterialInforId) ?? throw new ResourceNotFoundException(nameof(MaterialInfor), request.MaterialInforId);

            var materials = materialInfors.Materials
                .Where(x => x.Sku == request.Sku)
                .ToList();

            int totalItems = materials.Count();

            var queryResult = new QueryResult<Material>(materials, totalItems);

            return _mapper.Map<QueryResult<Material>, QueryResult<MaterialViewModel>>(queryResult);
        }
    }
}
