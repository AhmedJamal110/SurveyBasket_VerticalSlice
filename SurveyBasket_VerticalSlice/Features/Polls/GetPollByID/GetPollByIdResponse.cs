namespace SurveyBasket_VerticalSlice.Features.Polls.GetPollByID
{
    public record GetPollByIdResponse
        (
         int Id,
        string Title,
        string Summary,
        bool IsPublished,
        string CreatedBy,
        string UpdatedBy,
        DateTime CreatedOn,
        DateTime UpdatedOn,
         DateOnly StartsAt,
        DateOnly EndsAt

        );
}
