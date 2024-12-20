using FluentValidation;
namespace SurveyBasket_VerticalSlice.Features.Polls.CreatePoll
{
    public class CreatePollValidators : AbstractValidator<CreatePollRequest>
    {
        public CreatePollValidators()
        {
            RuleFor(x => x.Title)
                   .NotEmpty();

            RuleFor(x => x.Summary)
                    .NotEmpty();

            RuleFor(x => x.StratsAT)
                    .NotEmpty()
                    .GreaterThan(DateOnly.FromDateTime(DateTime.Today))
                    .WithMessage("Poll should strat greatrer than today");

            RuleFor(x => x.EndAt)
                 .NotEmpty();



        }
    }
}
