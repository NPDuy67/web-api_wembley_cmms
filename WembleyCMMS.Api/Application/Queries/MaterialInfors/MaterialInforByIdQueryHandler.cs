using WembleyCMMS.Domain.AggregateModels.MaterialInforAggregate;
using WembleyCMMS.Infrastructure;
using WembleyCMMS.Api.Application.Queries.MaterialInfors.Materials;

namespace WembleyCMMS.Api.Application.Queries.MaterialInfors
{
    public class MaterialInforByIdQueryHandler : IRequestHandler<MaterialInforByIdQuery, QueryResult<MaterialInforViewModel>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IMaterialInforRepository _materialInforRepository;

        public MaterialInforByIdQueryHandler(ApplicationDbContext context, IMapper mapper,
                                             IMaterialInforRepository materialInforRepository)
        { 
            _context = context;
            _mapper = mapper;
            _materialInforRepository = materialInforRepository;
        }

        public async Task<QueryResult<MaterialInforViewModel>> Handle(MaterialInforByIdQuery request, CancellationToken cancellationToken)
        {
            var queryable = _context.MaterialInfors
                .Include(x => x.MaterialHistoryCards)
                .Include(x => x.Materials)
                .AsNoTracking();

            if (request.MaterialInforId is not null)
            {
                queryable = queryable.Where(x => x.MaterialInforId == request.MaterialInforId);
            }

            int totalItems = await queryable.CountAsync();

            var requests = await queryable.ToListAsync();

            List<MaterialInforGetViewModel> materialInforGetViewModels = new List<MaterialInforGetViewModel>();
            foreach (MaterialInfor materialInfor in requests)
            {
                MaterialInforGetViewModel newGetViewModel = new MaterialInforGetViewModel(materialInfor.MaterialInforId);
                List<Material>? materials = materialInfor.Materials;
                List<MaterialViewModel> materialViewModels = _mapper.Map<List<Material>, List<MaterialViewModel>>(materials);
                //List<string> skus = materials?.Select(x => x.Sku).ToList();

                decimal currentQuantity = materialInfor.MaterialHistoryCards.Last().After;

                newGetViewModel.Update(code: materialInfor.Code,
                                       name: materialInfor.Name,
                                       unit: materialInfor.Unit,
                                       currentQuantity: currentQuantity,
                                       minimumQuantity: materialInfor.MinimumQuantity,
                                       materialHistoryCards: materialInfor.MaterialHistoryCards,
                                       materials: materialViewModels);
                materialInforGetViewModels.Add(newGetViewModel);
            }


            var queryResult = new QueryResult<MaterialInforGetViewModel>(materialInforGetViewModels, totalItems);

            return _mapper.Map<QueryResult<MaterialInforGetViewModel>, QueryResult<MaterialInforViewModel>>(queryResult);
        }
    }
}
