namespace SurveyBasket_VerticalSlice.Features.Questions.CreateQuestion
{
    public record CreateQuestionCommand(int PollId , CreateQuestionRequest Request) 
                                : IRequest<Result<CreateQuestionResponse>>;
    
}
