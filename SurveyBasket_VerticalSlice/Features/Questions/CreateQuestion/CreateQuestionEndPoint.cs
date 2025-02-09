

namespace SurveyBasket_VerticalSlice.Features.Questions.CreateQuestion
{
    public class CreateQuestionEndPoint(ControllerParamters controllerParamters) : BaseController(controllerParamters)
    {
        [HttpPost("{pollId}")]
        public async Task<ActionResult> Post([FromRoute] int pollId, [FromBody] CreateQuestionRequest request)
        {
            var result = await _Sender.Send(new CreateQuestionCommand(pollId, request));

            if (result.IsSuccess)
                return Ok(result.Value);

            return result.Error.Equals(PollError.PollNotFound)
                      ? result.ToProblem(StatusCodes.Status404NotFound)
                      : result.ToProblem(StatusCodes.Status409Conflict);
        }

    }
}
