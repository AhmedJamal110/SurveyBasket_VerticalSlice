namespace SurveyBasket_VerticalSlice.Features.Polls.GetPollByID
{
    public record GetPollByIdQuery(int id) : IRequest<Result<GetPollByIdResponse>>;
        
}
