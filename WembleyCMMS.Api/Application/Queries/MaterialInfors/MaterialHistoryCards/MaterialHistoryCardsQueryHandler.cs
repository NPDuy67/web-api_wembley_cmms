using Microsoft.IdentityModel.Tokens;
using System.Linq;
using WembleyCMMS.Domain.AggregateModels.MaterialInforAggregate;
using WembleyCMMS.Infrastructure;

namespace WembleyCMMS.Api.Application.Queries.MaterialInfors.MaterialHistoryCards
{
    public class MaterialHistoryCardsQueryHandler : IRequestHandler<MaterialHistoryCardsQuery, QueryResult<MaterialHistoryCardViewModel>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public MaterialHistoryCardsQueryHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<QueryResult<MaterialHistoryCardViewModel>> Handle(MaterialHistoryCardsQuery request, CancellationToken cancellationToken)
        {
            var materialInfor = await _context.MaterialInfors
                .Include(x => x.MaterialHistoryCards)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.MaterialInforId == request.MaterialInforId) ?? throw new ResourceNotFoundException(nameof(MaterialInfor), request.MaterialInforId);

            var materialHistoryCards = materialInfor.MaterialHistoryCards;

            int totalItems = materialHistoryCards.Count();

            var queryResult = new QueryResult<MaterialHistoryCard>(materialHistoryCards, totalItems);
            return _mapper.Map<QueryResult<MaterialHistoryCard>, QueryResult<MaterialHistoryCardViewModel>>(queryResult);
        }
    }
}
