
namespace SurveyBasket_VerticalSlice.Features.Polls.IsPollExist
{
    public class IsPollExistQueryHandler : IRequestHandler<IsPollExistQuery, bool>
    {
        private readonly IGenericRepository<Poll> _pollRepository;

        public IsPollExistQueryHandler(IGenericRepository<Poll> pollRepository)
        {
            _pollRepository = pollRepository;
        }
        public async Task<bool> Handle(IsPollExistQuery request, CancellationToken cancellationToken)
        {
           return await _pollRepository.IsEntityExsit(request.predicate);
        }
    }
}
