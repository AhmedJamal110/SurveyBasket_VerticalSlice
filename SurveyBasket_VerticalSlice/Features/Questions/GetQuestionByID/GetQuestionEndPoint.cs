
namespace SurveyBasket_VerticalSlice.Features.Questions.GetQuestionByID;

public class GetQuestionEndPoint : BaseController
{
    public GetQuestionEndPoint(ControllerParamters controllerParamters) : base(controllerParamters)
    {
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> Get( int pollId , [FromRoute] int id)
    {
        var result = await _Sender.Send(new GetQuestionByIdQuery(pollId, id));
        return result.IsSuccess
                ? Ok(result.Value) 
                : result.ToProblem(StatusCodes.Status500InternalServerError); 
    }
}
