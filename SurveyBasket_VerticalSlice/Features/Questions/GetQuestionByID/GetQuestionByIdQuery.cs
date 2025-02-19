namespace SurveyBasket_VerticalSlice.Features.Questions.GetQuestionByID;

public record GetQuestionByIdQuery(int pollId ,  int id) : IRequest<Result<GetQuestionByIdResponse>>;

