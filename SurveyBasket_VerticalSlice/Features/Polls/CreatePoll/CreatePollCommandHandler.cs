using SurveyBasket_VerticalSlice.Comman;
using SurveyBasket_VerticalSlice.Errors;
using SurveyBasket_VerticalSlice.Repository;

namespace SurveyBasket_VerticalSlice.Features.Polls.CreatePoll
{
    public class CreatePollCommandHandler : BaseRequestHandler<CreatePollCommand, Result<CreatePollResponse>>
    {
        private readonly IGenericRepository<Poll> _pollRepository;

        public CreatePollCommandHandler(IGenericRepository<Poll> pollRepository , RequestParameters parameters ) : base(parameters) 
        {
            _pollRepository = pollRepository;
        }

        public override async Task<Result<CreatePollResponse>> Handle(CreatePollCommand request, CancellationToken cancellationToken)
        {
            bool isExsit = await _pollRepository.IsEntityExsit(x => x.Title == request.Title);
            if (isExsit)
                return Result.Failure<CreatePollResponse>(PollError.PollDeplucated);

            var pollInDb = request.Adapt<Poll>();
           // var pollInDb = request.MapOne<Poll>();
            var result = await  _pollRepository.AddAsync(pollInDb);

            return result is null
                ? Result.Failure<CreatePollResponse>(PollError.ErrorSavePoll)
                : Result.Success(result.Adapt<CreatePollResponse>());
        }
    }
}
