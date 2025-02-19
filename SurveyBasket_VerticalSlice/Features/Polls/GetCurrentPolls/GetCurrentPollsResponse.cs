namespace SurveyBasket_VerticalSlice.Features.Polls.GetCurrentPolls;

public record GetCurrentPollsResponse
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
