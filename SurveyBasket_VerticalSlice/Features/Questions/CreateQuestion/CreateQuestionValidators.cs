namespace SurveyBasket_VerticalSlice.Features.Questions.CreateQuestion
{
    public class CreateQuestionValidators : AbstractValidator<CreateQuestionRequest>
    {
        public CreateQuestionValidators()
        {
            RuleFor(ques => ques.Content)
                                      .NotEmpty().Length(3, 1000);

            RuleFor(ques => ques.Answers)
                                .Must(ans => ans.Count > 1)
                                .WithMessage("Question should has at least 2 answers");

            RuleFor(ques => ques.Answers)
                                    .Must(ans => ans.Distinct().Count() == ans.Count)
                                    .WithMessage("you cannt add the same answer");
            
        }
    }
}
