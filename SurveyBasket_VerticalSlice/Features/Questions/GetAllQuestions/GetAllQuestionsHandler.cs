
using System.Linq.Dynamic.Core;
using SurveyBasket_VerticalSlice.Features.Polls.IsPollExist;

namespace SurveyBasket_VerticalSlice.Features.Questions.GetAllQuestions;

public class GetAllQuestionsHandler : BaseRequestHandler<GetAllQuestionsQuery, Result<PaginatedList<GetAllQuestionsResponse>>>
{
    private readonly IGenericRepository<Question> _genericRepository;

    public GetAllQuestionsHandler(RequestParameters parameters, IGenericRepository<Question> genericRepository) : base(parameters)
    {
        _genericRepository = genericRepository;
    }

    public async  override Task<Result<PaginatedList<GetAllQuestionsResponse>>> Handle(GetAllQuestionsQuery request, CancellationToken cancellationToken)
    {

        var pollInDb = await _sender.Send(new IsPollExistQuery(poll => poll.Id == request.pollId));

        if (!pollInDb)
            return Result.Failure<PaginatedList<GetAllQuestionsResponse>>(PollError.PollNotFound);

        var questions = _genericRepository.GetAllAsync()
                                                            .Where(qus => qus.PollId == request.pollId);

        if (!string.IsNullOrEmpty(request.Filter.SearchTerm))
             questions = questions.Where(qus => qus.Content.Contains(request.Filter.SearchTerm));

        // Linq Dynamic Core Package

        if (!string.IsNullOrEmpty(request.Filter.SortColumn))
             questions = questions.OrderBy($"{request.Filter.SortColumn} {request.Filter.SortDirection}");

         var source =  questions.ProjectToType<GetAllQuestionsResponse>();
                                                          
         var response = await PaginatedList<GetAllQuestionsResponse>.CreatetAsync(source, request.Filter.PageNumber , request.Filter.PageSize);



        return response is not null
                    ? Result.Success(response)
                    : Result.Failure<PaginatedList<GetAllQuestionsResponse>>(QuestionError.QuestionNotFound);
    
    }
}
