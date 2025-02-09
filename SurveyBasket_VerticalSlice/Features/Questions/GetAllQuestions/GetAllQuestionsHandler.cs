
using Microsoft.AspNetCore.Http.HttpResults;
using SurveyBasket_VerticalSlice.Features.Answers.CreateAnswer;
using SurveyBasket_VerticalSlice.Features.Polls.GetPollByID;
using SurveyBasket_VerticalSlice.Features.Polls.IsPollExist;

namespace SurveyBasket_VerticalSlice.Features.Questions.GetAllQuestions;

public class GetAllQuestionsHandler : BaseRequestHandler<GetAllQuestionsQuery, Result<IEnumerable<GetAllQuestionsResponse>>>
{
    private readonly IGenericRepository<Question> _genericRepository;

    public GetAllQuestionsHandler(RequestParameters parameters, IGenericRepository<Question> genericRepository) : base(parameters)
    {
        _genericRepository = genericRepository;
    }

    public async  override Task<Result<IEnumerable<GetAllQuestionsResponse>>> Handle(GetAllQuestionsQuery request, CancellationToken cancellationToken)
    {

        var pollInDb = await _sender.Send(new IsPollExistQuery(poll => poll.Id == request.pollId));

        if (!pollInDb)
            return Result.Failure<IEnumerable<GetAllQuestionsResponse>>(PollError.PollNotFound);

        var questions = await _genericRepository.GetAllAsync()
                                                                  .Where(qus => qus.PollId == request.pollId)
                                                                  .ProjectToType<GetAllQuestionsResponse>() 
                                                                  .ToListAsync (cancellationToken);


        return questions is not null
                    ? Result.Success<IEnumerable<GetAllQuestionsResponse>>(questions)
                    : Result.Failure<IEnumerable<GetAllQuestionsResponse>>(QuestionError.QuestionNotFound);
    
    }
}
