namespace SurveyBasket_VerticalSlice.Features.Questions.CreateQuestion
{
    public record CreateQuestionRequest
    (
        string Content,
        List<string> Answers
     );
}
