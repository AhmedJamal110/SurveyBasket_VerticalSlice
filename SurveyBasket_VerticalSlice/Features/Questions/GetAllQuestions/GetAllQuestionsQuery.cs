namespace SurveyBasket_VerticalSlice.Features.Questions.GetAllQuestions;

public record GetAllQuestionsQuery(int pollId) : IRequest<Result<IEnumerable<GetAllQuestionsResponse>>>;

