namespace SurveyBasket_VerticalSlice.Features.Polls.GetPollByID
{
    public class GetPollByIdValidatiion : AbstractValidator<GetPollByIDRequest>
    {
        public GetPollByIdValidatiion()
        {
            RuleFor(poll => poll.id).NotEmpty();
        }
    }
}
