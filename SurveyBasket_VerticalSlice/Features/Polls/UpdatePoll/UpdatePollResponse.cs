namespace SurveyBasket_VerticalSlice.Features.Polls.UpdatePoll
{
    public record UpdatePollResponse
    (
        int Id,
        string Title,
        string Summary,
        bool IsPublished,
        DateOnly StartsAt,
        DateOnly EndsAt
    );
}
