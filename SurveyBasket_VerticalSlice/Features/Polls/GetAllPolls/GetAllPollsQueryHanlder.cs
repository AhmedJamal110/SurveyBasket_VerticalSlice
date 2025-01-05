namespace SurveyBasket_VerticalSlice.Features.Polls.GetAllPolls
{
    public class GetAllPollsQueryHanlder : BaseRequestHandler<GetAllPollsQuery , Result<IEnumerable<GetAllPollsResponse>>>
    {
        private readonly IGenericRepository<Poll> _pollReposatory;

        public GetAllPollsQueryHanlder(RequestParameters parameters , IGenericRepository<Poll> pollReposatory)  : base(parameters)
        {
            _pollReposatory = pollReposatory;
        }

        public override async Task<Result<IEnumerable<GetAllPollsResponse>>> Handle(GetAllPollsQuery request, CancellationToken cancellationToken)
        {
            var polls = await _pollReposatory.GetAllAsync().ToListAsync();

            return polls.Count == 0
                ? Result.Failure<IEnumerable<GetAllPollsResponse> >(PollError.PollNotFound)
                : Result.Success(polls.Adapt< IEnumerable<GetAllPollsResponse>>());

        }

    }
}
