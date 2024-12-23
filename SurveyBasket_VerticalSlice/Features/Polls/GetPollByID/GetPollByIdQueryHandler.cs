namespace SurveyBasket_VerticalSlice.Features.Polls.GetPollByID
{
    public class GetPollByIdQueryHandler : BaseRequestHandler<GetPollByIdQuery, Result<GetPollByIdResponse>>
    {
        private readonly IGenericRepository<Poll> _pollRepository;

        public GetPollByIdQueryHandler(RequestParameters parameters , IGenericRepository<Poll> pollRepository) : base(parameters)
        {
            _pollRepository = pollRepository;
        }

        public override async Task<Result<GetPollByIdResponse>> Handle(GetPollByIdQuery request, CancellationToken cancellationToken)
        {
            var pollInDb = await _pollRepository.GetByIdAsync(request.id);

            return pollInDb is null
                    ? Result.Failure<GetPollByIdResponse>(PollError.PollNotFound)
                    : Result.Success(pollInDb.Adapt<GetPollByIdResponse>());
        }


    }
}
