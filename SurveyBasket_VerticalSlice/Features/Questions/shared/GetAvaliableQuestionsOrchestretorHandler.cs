using Microsoft.VisualBasic;
using SurveyBasket_VerticalSlice.Features.Questions.GetAllQuestions;
using SurveyBasket_VerticalSlice.Features.Questions.GetAvaliableQuestions;

namespace SurveyBasket_VerticalSlice.Features.Questions.shared;

public class GetAvaliableQuestionsOrchestretorHandler : BaseRequestHandler<GetAvaliableQuestionsQuery, Result<IEnumerable<GetAvaliableQuestionsResponse>>>
{
    private readonly IGenericRepository<Vote> _voteRepository;
    private readonly IGenericRepository<Question> _questionRepository;
    private readonly IGenericRepository<Poll> _pollRepository;

    public GetAvaliableQuestionsOrchestretorHandler(RequestParameters parameters 
        , IGenericRepository<Vote> voteRepository , IGenericRepository<Question> questionRepository , IGenericRepository<Poll> pollRepository ) : base(parameters)
    {
        _voteRepository = voteRepository;
        _questionRepository = questionRepository;
        _pollRepository = pollRepository;
    }

    public override async Task<Result<IEnumerable<GetAvaliableQuestionsResponse>>> Handle(GetAvaliableQuestionsQuery request, CancellationToken cancellationToken)
    {
        var isUserVoted = await _voteRepository.IsEntityExsit(vot => vot.PollId == request.PollID  && vot.UserId == request.UserId);
           if (isUserVoted)
               return Result.Failure<IEnumerable<GetAvaliableQuestionsResponse>>(VoteErrors.DuplicatedVoted);

        var isPollExsite = await _pollRepository.IsEntityExsit(poll => poll.Id == request.PollID && poll.IsPublished 
                            && poll.StratsAT <= DateOnly.FromDateTime(DateTime.UtcNow) && poll.EndAt >= DateOnly.FromDateTime(DateTime.UtcNow));

            if(!isPollExsite)
               return Result.Failure<IEnumerable<GetAvaliableQuestionsResponse>>(PollError.PollNotFound);


        var questiuons = await _questionRepository.GetAllAsync()
                                                                       .Where(ques => ques.PollId == request.PollID && ques.IsActive)
                                                                       .ProjectToType<GetAvaliableQuestionsResponse>()
                                                                       .ToListAsync();

        return Result.Success<IEnumerable<GetAvaliableQuestionsResponse>>(questiuons);
    }
}
