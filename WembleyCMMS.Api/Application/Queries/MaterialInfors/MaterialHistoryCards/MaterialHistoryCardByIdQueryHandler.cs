using WembleyCMMS.Domain.AggregateModels.MaterialInforAggregate;
using WembleyCMMS.Infrastructure;

namespace WembleyCMMS.Api.Application.Queries.MaterialInfors.MaterialHistoryCards
{
    public class MaterialHistoryCardByIdQueryHandler : IRequestHandler<MaterialHistoryCardByIdQuery, QueryResult<MaterialHistoryCardViewModel>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public MaterialHistoryCardByIdQueryHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<QueryResult<MaterialHistoryCardViewModel>> Handle(MaterialHistoryCardByIdQuery request, CancellationToken cancellationToken)
        {
            var materialInfors = await _context.MaterialInfors
                .Include(x => x.MaterialHistoryCards)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.MaterialInforId == request.MaterialInforId) ?? throw new ResourceNotFoundException(nameof(MaterialInfor), request.MaterialInforId);

            var materialHistoryCards = materialInfors.MaterialHistoryCards
                .Where(x => x.MaterialHistoryCardId == request.MaterialHistoryCardId)
                .ToList();

            int totalItems = materialHistoryCards.Count();

            var queryResult = new QueryResult<MaterialHistoryCard>(materialHistoryCards, totalItems);

            return _mapper.Map<QueryResult<MaterialHistoryCard>, QueryResult<MaterialHistoryCardViewModel>>(queryResult);
        }
    }
}
