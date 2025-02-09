namespace SurveyBasket_VerticalSlice.Features.Polls.CreatePoll
{
    [Route("api/polls")]
    public class CreatePollEndPoint(ControllerParamters paramters) : BaseController(paramters)
    {
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreatePollRequest request)
        {

            var result = await _Sender.Send(new CreatePollCommand
               (
                   request.Title,
                   request.Summary,
                   request.StratsAT,
                   request.EndAt
               ));

            return result.IsSuccess ? Ok(result.Value) : result.ToProblem(StatusCodes.Status400BadRequest);
        }
    }
}
