
namespace SurveyBasket_VerticalSlice.Features.Polls.GetCurrentPolls;

public class GetCurrentPollsHandler : BaseRequestHandler<GetCurrentPollsCommand, Result< IEnumerable<GetCurrentPollsResponse>>>
{
    private readonly IGenericRepository<Poll> _genericRepository;

    public GetCurrentPollsHandler(RequestParameters parameters , IGenericRepository<Poll> genericRepository) : base(parameters)
    {
        _genericRepository = genericRepository;
    }

    public override async Task<Result<IEnumerable< GetCurrentPollsResponse>>> Handle(GetCurrentPollsCommand request, CancellationToken cancellationToken)
    {
         var currentPolls = await _genericRepository.GetAllAsync().Where(poll => poll.IsPublished
                                                                                           && poll.StratsAT <= DateOnly.FromDateTime(DateTime.UtcNow) 
                                                                                           && poll.EndAt >=  DateOnly.FromDateTime(DateTime.UtcNow))
                                                                                         .ProjectToType<GetCurrentPollsResponse>()
                                                                                        .ToListAsync();

        return currentPolls is null
        ? Result.Failure<IEnumerable<GetCurrentPollsResponse>>(PollError.PollNotFound)
        : Result.Success<IEnumerable<GetCurrentPollsResponse>>(currentPolls);
            
    }

}
