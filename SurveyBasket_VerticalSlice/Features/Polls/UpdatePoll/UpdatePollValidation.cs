
namespace SurveyBasket_VerticalSlice.Features.Polls.UpdatePoll
{
    public class UpdatePollValidation : AbstractValidator<UpdatePollRequest>
    {
        public UpdatePollValidation()
        {
            RuleFor(poll => poll.Title).NotEmpty();
            RuleFor(poll => poll.Summary).NotEmpty();
       

        }

      

    }
    
}
