using SurveyBasket_VerticalSlice.Features.Answers.CreateAnswer;

namespace SurveyBasket_VerticalSlice.Features.Questions.GetAvaliableQuestions;

public record GetAvaliableQuestionsResponse
(
    int Id,
    string Content,
   IEnumerable<Answer> Answers
 );
