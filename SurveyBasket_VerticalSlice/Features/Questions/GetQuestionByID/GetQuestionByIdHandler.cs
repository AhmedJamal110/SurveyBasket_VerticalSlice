
namespace SurveyBasket_VerticalSlice.Features.Questions.GetQuestionByID;

public class GetQuestionByIdHandler : BaseRequestHandler<GetQuestionByIdQuery, Result<GetQuestionByIdResponse>>
{
    private readonly IGenericRepository<Question> _genericRepository;

    public GetQuestionByIdHandler(RequestParameters parameters , IGenericRepository<Question> genericRepository) : base(parameters)
    {
       _genericRepository = genericRepository;
    }

    public override async Task<Result<GetQuestionByIdResponse>> Handle(GetQuestionByIdQuery request, CancellationToken cancellationToken)
    {
        var question = await _genericRepository.FirstAsync<GetQuestionByIdResponse>(qus => qus.PollId == request.pollId && qus.Id == request.id);
        
            if(question == null) 
                return Result.Failure<GetQuestionByIdResponse>(QuestionError.QuestionNotFound);

        return Result.Success(question);
    }
}
