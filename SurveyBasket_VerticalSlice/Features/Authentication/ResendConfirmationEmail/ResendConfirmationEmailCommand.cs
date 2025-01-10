namespace SurveyBasket_VerticalSlice.Features.Authentication.ResendConfirmationEmail
{
    public record ResendConfirmationEmailCommand(string Email) : IRequest<Result>;

}
