namespace SurveyBasket_VerticalSlice.Features.Authentication.ConfirmEmail;

    public record ConfirmEmailCommand(string UserId , string Code): IRequest<Result>;

