namespace SurveyBasket_VerticalSlice.Features.Polls.GetPollByID
{
    public class GetPollByIdEndPoint : BaseController
    {
        public GetPollByIdEndPoint(ControllerParamters controllerParamters) : base(controllerParamters)
        {
        }
        [HttpGet("poll")]
        public async Task<ActionResult> Get([FromQuery]GetPollByIDRequest request)
        {
           var poll = await _Sender.Send(new GetPollByIdQuery(request.id));

            return poll.IsSuccess ? Ok(poll.Value) : poll.ToProblem(StatusCodes.Status404NotFound); 
        }
    }
}
