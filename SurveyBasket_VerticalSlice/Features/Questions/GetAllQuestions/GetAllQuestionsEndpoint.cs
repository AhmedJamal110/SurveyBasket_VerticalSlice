
namespace SurveyBasket_VerticalSlice.Features.Questions.GetAllQuestions;

public class GetAllQuestionsEndpoint : BaseController
{
    public GetAllQuestionsEndpoint(ControllerParamters controllerParamters) : base(controllerParamters)
    {
    }

    [HttpGet]
    public async Task<ActionResult> GetAll([FromQuery] int pollId , [FromQuery] RequestFilter filter)
    {
        var result = await _Sender.Send(new GetAllQuestionsQuery(pollId , filter));
    
        return result.IsSuccess ? Ok(result.Value) : result.ToProblem(StatusCodes.Status404NotFound);
    }
}
