namespace SurveyBasket_VerticalSlice.Features.Polls.GetAllPolls
{
    public record GetAllPollsResponse
     (
        int Id,
        string Title,
        string Summary,
        bool IsPublished,
        DateOnly StartsAt,
        DateOnly EndsAt,
        string CreatedBy,
        string UpdatedBy,
        DateTime CreatedOn,
        DateTime UpdatedOn

    );
            
}
