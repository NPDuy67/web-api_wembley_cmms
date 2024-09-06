using WembleyCMMS.Domain.AggregateModels.MaterialInforAggregate;
using WembleyCMMS.Infrastructure;
using static WembleyCMMS.Domain.AggregateModels.MaterialInforAggregate.MaterialRequest;

namespace WembleyCMMS.Api.Application.Queries.MaterialInfors.MaterialRequests
{
    public class MaterialRequestsQueryHandler : IRequestHandler<MaterialRequestsQuery, QueryResult<MaterialRequestViewModel>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public MaterialRequestsQueryHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<QueryResult<MaterialRequestViewModel>> Handle(MaterialRequestsQuery request, CancellationToken cancellationToken)
        {
            var materialInfor = await _context.MaterialInfors
                .Include(x => x.MaterialRequests)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.MaterialInforId == request.MaterialInforId) ?? throw new ResourceNotFoundException(nameof(MaterialInfor), request.MaterialInforId);

            var materialRequests = materialInfor.MaterialRequests.Where(x => x.Status == EMaterialRequestStatus.InProgress);

            if (request.StartDate is not null && request.EndDate is not null)
            {
                materialRequests = materialRequests.Where(x => x.CreatedAt >= request.StartDate && x.CreatedAt <= request.EndDate).ToList();
            }

            if (request.Status is not null)
            {
                materialRequests = materialRequests.Where(x => x.Status == request.Status).ToList();
            }

            int totalItems = materialRequests.Count();

            var listGetViewModel = new List<MaterialRequestGetViewModel>();
            foreach (MaterialRequest materialRequest in materialRequests)
            {
                var newGetViewModel = new MaterialRequestGetViewModel(materialRequest.MaterialRequestId);
                newGetViewModel.Code = materialRequest.Code;
                newGetViewModel.MaterialInfor = materialRequest.MaterialInfor;
                newGetViewModel.CurrentNumber = materialRequest.CurrentNumber;
                newGetViewModel.AdditionalNumber = materialRequest.AdditionalNumber;
                newGetViewModel.ExpectedNumber = materialRequest.ExpectedNumber;
                newGetViewModel.ExpectedDate = materialRequest.ExpectedDate;
                newGetViewModel.CreatedAt = materialRequest.CreatedAt;
                newGetViewModel.UpdatedAt = materialRequest.UpdatedAt;
                newGetViewModel.Status = materialRequest.Status.ToString();
                listGetViewModel.Add(newGetViewModel);
            }

            var queryResult = new QueryResult<MaterialRequestGetViewModel>(listGetViewModel, totalItems);

            return _mapper.Map<QueryResult<MaterialRequestGetViewModel>, QueryResult<MaterialRequestViewModel>>(queryResult);
        }
    }
}
