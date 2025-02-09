using SurveyBasket_VerticalSlice.Features.Answers.CreateAnswer;

namespace SurveyBasket_VerticalSlice.Features.Questions.CreateQuestion
{
    public record CreateQuestionResponse
    (
        int Id,
        string Content,
        IEnumerable<CreateAnswerResponse> Answers
      );
}
