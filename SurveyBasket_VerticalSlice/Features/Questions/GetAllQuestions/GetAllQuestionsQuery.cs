namespace SurveyBasket_VerticalSlice.Features.Questions.GetAllQuestions;

public record GetAllQuestionsQuery(int pollId , RequestFilter Filter)
                    : IRequest<Result<PaginatedList<GetAllQuestionsResponse>>>;

