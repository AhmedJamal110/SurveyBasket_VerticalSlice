namespace SurveyBasket_VerticalSlice.Features.Polls.UpdatePoll
{
    public class UpdatePollEndPoint : BaseController
    {
        public UpdatePollEndPoint(ControllerParamters controllerParamters) : base(controllerParamters)
        {
            
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Edit( int id , [FromBody]UpdatePollRequest request)
         {
            var result = await _Sender.Send(new UpdatePollCommand
                        (id, request.Title, request.Summary));

            if (result.IsSuccess)
                return Ok(result);


            return result.Error.Equals(PollError.PollNotFound)
                 ? result.ToProblem(StatusCodes.Status404NotFound)
                 : result.ToProblem(StatusCodes.Status409Conflict);
      
          }
    }
}
