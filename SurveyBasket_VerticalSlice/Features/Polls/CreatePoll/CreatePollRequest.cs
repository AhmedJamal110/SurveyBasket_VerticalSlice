namespace SurveyBasket_VerticalSlice.Features.Polls.CreatePoll
{
    public record CreatePollRequest
     (
        string Title,
        string Summary,
        DateOnly StratsAT,
        DateOnly EndAt
     );
}
