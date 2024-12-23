namespace SurveyBasket_VerticalSlice.Features.Polls.GetAllPolls
{
    public record GetAllPollsQuery : IRequest<Result<IEnumerable<GetAllPollsResponse>>>;
    
}
