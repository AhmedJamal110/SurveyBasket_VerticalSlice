
namespace SurveyBasket_VerticalSlice.Features.Polls.GetCurrentPolls;

public class GetCurrentPollsEndpoint : BaseController
{
    public GetCurrentPollsEndpoint(ControllerParamters controllerParamters) : base(controllerParamters)
    {
    }

    [HttpGet]
    public async Task<ActionResult> Get()
    {
        var result = await _Sender.Send(new GetCurrentPollsCommand());
          return result.IsSuccess ? Ok(result.Value) : result.ToProblem(StatusCodes.Status500InternalServerError);
    }
}
