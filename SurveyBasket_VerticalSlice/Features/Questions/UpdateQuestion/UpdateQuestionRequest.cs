namespace SurveyBasket_VerticalSlice.Features.Questions.UpdateQuestion;

public record UpdateQuestionRequest
(
    string Content,
    List<string> Answers
 );
