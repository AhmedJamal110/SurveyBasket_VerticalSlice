namespace SurveyBasket_VerticalSlice.Features.Polls.GetCurrentPolls;

public record GetCurrentPollsCommand : IRequest<Result<IEnumerable<GetCurrentPollsResponse>>>;
