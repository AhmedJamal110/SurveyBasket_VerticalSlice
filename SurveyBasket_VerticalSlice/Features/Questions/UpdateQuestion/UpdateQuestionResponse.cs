using SurveyBasket_VerticalSlice.Features.Answers.CreateAnswer;

namespace SurveyBasket_VerticalSlice.Features.Questions.UpdateQuestion;

public record UpdateQuestionResponse
(
    int Id,
    string Content,
   IEnumerable<CreateAnswerResponse> Answers
);
