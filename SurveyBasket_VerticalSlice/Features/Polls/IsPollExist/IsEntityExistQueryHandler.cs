
namespace SurveyBasket_VerticalSlice.Features.Polls.IsPollExist
{
    public class IsEntityExistQueryHandler : IRequestHandler<IsEntityExistQuery, bool>
    {
        private readonly IGenericRepository<Poll> _pollRepository;

        public IsEntityExistQueryHandler(IGenericRepository<Poll> pollRepository)
        {
            _pollRepository = pollRepository;
        }
        public async Task<bool> Handle(IsEntityExistQuery request, CancellationToken cancellationToken)
        {
           return await _pollRepository.IsEntityExsit(request.predicate);
        }
    }
}
