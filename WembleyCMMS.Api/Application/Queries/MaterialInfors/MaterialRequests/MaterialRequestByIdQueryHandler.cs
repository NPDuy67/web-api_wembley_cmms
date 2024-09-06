using WembleyCMMS.Domain.AggregateModels.MaterialInforAggregate;
using WembleyCMMS.Infrastructure;

namespace WembleyCMMS.Api.Application.Queries.MaterialInfors.MaterialRequests
{
    public class MaterialRequestByIdQueryHandler : IRequestHandler<MaterialRequestByIdQuery, QueryResult<MaterialRequestViewModel>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public MaterialRequestByIdQueryHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<QueryResult<MaterialRequestViewModel>> Handle(MaterialRequestByIdQuery request, CancellationToken cancellationToken)
        {
            var materialInfors = await _context.MaterialInfors
                .Include(x => x.MaterialRequests)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.MaterialInforId == request.MaterialInforId) ?? throw new ResourceNotFoundException(nameof(MaterialInfor), request.MaterialInforId);

            var materialRequests = materialInfors.MaterialRequests
               .Where(x => x.MaterialRequestId == request.MaterialRequestId)
               .ToList();

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
