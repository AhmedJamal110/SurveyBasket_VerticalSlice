namespace SurveyBasket_VerticalSlice.Features.Questions.UpdateQuestion;

public record UpdateQuestionComand(int pollId , int id , UpdateQuestionRequest Request) 
                        : IRequest<Result<UpdateQuestionResponse>>;

