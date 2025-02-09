namespace SurveyBasket_VerticalSlice.Features.Polls.GetPollByID
{
    [Route("api/polls")]
    public class GetPollByIdEndPoint(ControllerParamters controllerParamters) : BaseController(controllerParamters)
    {
        [HttpGet]
        public async Task<ActionResult> Get([FromQuery]GetPollByIDRequest request)
        {
           var poll = await _Sender.Send(new GetPollByIdQuery(request.id));

            return poll.IsSuccess ? Ok(poll.Value) : poll.ToProblem(StatusCodes.Status404NotFound); 
        }
    }
}
