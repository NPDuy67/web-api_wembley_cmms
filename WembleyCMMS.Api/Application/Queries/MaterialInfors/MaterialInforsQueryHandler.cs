using WembleyCMMS.Api.Application.Queries.MaterialInfors.Materials;
using WembleyCMMS.Domain.AggregateModels.MaterialInforAggregate;
using WembleyCMMS.Infrastructure;

namespace WembleyCMMS.Api.Application.Queries.MaterialInfors
{
    public class MaterialInforsQueryHandler : IRequestHandler<MaterialInforsQuery, QueryResult<MaterialInforViewModel>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public MaterialInforsQueryHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<QueryResult<MaterialInforViewModel>> Handle(MaterialInforsQuery request, CancellationToken cancellationToken)
        {
            var queryable = _context.MaterialInfors
                .Include(x => x.MaterialHistoryCards)
                .Include(x => x.Materials)
                .AsNoTracking();

            if (request.IdStartedWith is not null)
            {
                queryable = queryable.Where(x => x.MaterialInforId.StartsWith(request.IdStartedWith));
            }

            if (request.Paginated)
            {
                queryable = queryable
                    .OrderBy(x => x.MaterialInforId)
                    .Skip((request.PageIndex - 1) * request.PageSize)
                    .Take(request.PageSize);
            }

            int totalItems = await queryable.CountAsync();
            var materialInfors = await queryable.ToListAsync();

            List<MaterialInforGetViewModel> materialInforGetViewModels = new List<MaterialInforGetViewModel>();
            foreach(MaterialInfor materialInfor in materialInfors)
            {
                MaterialInforGetViewModel newGetViewModel = new MaterialInforGetViewModel(materialInfor.MaterialInforId);
                List<Material>? materials = materialInfor.Materials;
                List<MaterialViewModel> materialViewModels = _mapper.Map<List<Material>, List<MaterialViewModel>>(materials);
                //List<string> skus = materials?.Select(x => x.Sku).ToList();

                decimal currentQuantity = materialInfor.MaterialHistoryCards.Any() ? materialInfor.MaterialHistoryCards.Last().After : 0;

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
