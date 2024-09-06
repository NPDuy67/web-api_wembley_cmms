using WembleyCMMS.Domain.AggregateModels.MaterialInforAggregate;
using WembleyCMMS.Infrastructure;

namespace WembleyCMMS.Api.Application.Queries.MaterialInfors.Materials
{
    public class MaterialsQueryHandler : IRequestHandler<MaterialsQuery, QueryResult<MaterialViewModel>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public MaterialsQueryHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<QueryResult<MaterialViewModel>> Handle(MaterialsQuery request, CancellationToken cancellationToken)
        {
            var materialInfor = await _context.MaterialInfors
                .Include(x => x.Materials)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.MaterialInforId == request.MaterialInforId) ?? throw new ResourceNotFoundException(nameof(MaterialInfor), request.MaterialInforId);

            var materials = materialInfor.Materials;

            if (request.Status is not null)
            {
                materials = materials.Where(x => x.Status == request.Status).ToList();
            }

            int totalItems = materials.Count();

            var queryResult = new QueryResult<Material>(materials, totalItems);
            return _mapper.Map<QueryResult<Material>, QueryResult<MaterialViewModel>>(queryResult);
        }
    }
}
