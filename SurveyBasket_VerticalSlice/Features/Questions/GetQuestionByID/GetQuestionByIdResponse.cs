using SurveyBasket_VerticalSlice.Features.Answers.CreateAnswer;

namespace SurveyBasket_VerticalSlice.Features.Questions.GetQuestionByID;

public record GetQuestionByIdResponse
(
     int Id,
     string Content,
     IEnumerable<CreateAnswerResponse> Answers
 );
