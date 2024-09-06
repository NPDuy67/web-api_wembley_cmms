using WembleyCMMS.Domain.AggregateModels.MaterialInforAggregate;
using WembleyCMMS.Infrastructure;

namespace WembleyCMMS.Api.Application.Queries.MaterialInfors.Materials
{
    public class MaterialByIdQueryHandler : IRequestHandler<MaterialByIdQuery, QueryResult<MaterialViewModel>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public MaterialByIdQueryHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<QueryResult<MaterialViewModel>> Handle(MaterialByIdQuery request, CancellationToken cancellationToken)
        {
            var materialInfors = await _context.MaterialInfors
                .Include(x => x.Materials)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.MaterialInforId == request.MaterialInforId) ?? throw new ResourceNotFoundException(nameof(MaterialInfor), request.MaterialInforId);

            var materials = materialInfors.Materials
                .Where(x => x.MaterialId == request.MaterialId)
                .ToList();

            int totalItems = materials.Count();

            var queryResult = new QueryResult<Material>(materials, totalItems);

            return _mapper.Map<QueryResult<Material>, QueryResult<MaterialViewModel>>(queryResult);
        }
    }
}
