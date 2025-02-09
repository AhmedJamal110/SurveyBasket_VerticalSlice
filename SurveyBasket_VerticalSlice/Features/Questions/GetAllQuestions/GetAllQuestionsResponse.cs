using SurveyBasket_VerticalSlice.Features.Answers.CreateAnswer;

namespace SurveyBasket_VerticalSlice.Features.Questions.GetAllQuestions;

public record GetAllQuestionsResponse
(
    int Id,
    string Content,
   IEnumerable<CreateAnswerResponse> Answers
 );
