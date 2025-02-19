
namespace SurveyBasket_VerticalSlice.Features.Questions.UpdateQuestion;

public class UpdateQuestionHandler : BaseRequestHandler<UpdateQuestionComand, Result<UpdateQuestionResponse>>
{
    private readonly IGenericRepository<Question> _genericRepository;

    public UpdateQuestionHandler(RequestParameters parameters , IGenericRepository<Question> genericRepository) : base(parameters)
    {
        _genericRepository = genericRepository;
    }

    public override async Task<Result<UpdateQuestionResponse>> Handle(UpdateQuestionComand request, CancellationToken cancellationToken)
    {

        var isExist = await _genericRepository.IsEntityExsit(qus => qus.Id == request.id && qus.PollId == request.pollId && qus.Content == request.Request.Content);

            if(isExist)
                    return Result.Failure<UpdateQuestionResponse>(QuestionError.QuestionlDeplucated);

            var question = await _genericRepository.FirstWithIncludeAsync( ques => ques.Id == request.id && ques.PollId == request.pollId 
                                                                                                                , ques => ques.Answers );
                if(question == null)
                        return Result.Failure<UpdateQuestionResponse>(QuestionError.QuestionNotFound);

                question.Content = request.Request.Content;

                ///  answers  
            
            var currentAnswers = question.Answers.Select(ans => ans.Content).ToList();
            var newAnswers = request.Request.Answers.Except(currentAnswers).ToList();

                newAnswers.ForEach(answer =>
                {
                    question.Answers.Add(new Answer { Content = answer });
                });


        /// make old answers not active 

                question.Answers.ToList().ForEach(answer =>
                {
                    answer.IsActive = request.Request.Answers.Contains(answer.Content);
                });


        return Result.Success(question.Adapt<UpdateQuestionResponse>());

    }
}
