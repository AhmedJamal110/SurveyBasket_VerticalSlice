
namespace SurveyBasket_VerticalSlice.Features.Questions.QuestionToggle;

public class QuestionToggleHandler : BaseRequestHandler<QuestionToggleComman, Result>
{
    private readonly IGenericRepository<Question> _genericRepository;

    public QuestionToggleHandler(RequestParameters parameters , IGenericRepository<Question> genericRepository) : base(parameters)
    {
        _genericRepository = genericRepository;
    }

    public override async Task<Result> Handle(QuestionToggleComman request, CancellationToken cancellationToken)
    {
        var question = await _genericRepository.FirstAsync(qus => qus.PollId == request.pollId && qus.Id == request.Id);

        if (question == null)
            return Result.Failure(QuestionError.QuestionNotFound);

            question.IsActive = ! question.IsActive;
        
        return Result.Success();
        
    }
}
