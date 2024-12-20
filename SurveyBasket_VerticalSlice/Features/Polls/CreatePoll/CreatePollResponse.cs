namespace SurveyBasket_VerticalSlice.Features.Polls.CreatePoll
{
    public record CreatePollResponse
        (
            int Id,
            string Title,
            string Summary,
            bool IsPublished,
            DateOnly StartsAt,
            DateOnly EndsAt
        );
}
