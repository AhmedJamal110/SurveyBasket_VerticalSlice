namespace SurveyBasket_VerticalSlice.Features.Polls.UpdatePoll
{
    public record UpdatePollCommand (int 
        Id ,  string Title, string Summary)
        : IRequest<Result>;
    
}
