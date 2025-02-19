namespace SurveyBasket_VerticalSlice.Features.Questions.GetAvaliableQuestions;

public record GetAvaliableQuestionsQuery(int PollID ,  string UserId) 
            :IRequest<Result<IEnumerable<GetAvaliableQuestionsResponse>>>;
