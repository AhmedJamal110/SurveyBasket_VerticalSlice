using Microsoft.AspNetCore.Mvc;
using SurveyBasket_VerticalSlice.Abstractions;
using SurveyBasket_VerticalSlice.Comman;

namespace SurveyBasket_VerticalSlice.Features.Polls.CreatePoll
{
    public class CreatePollEndPoint : BaseController
    {
        public CreatePollEndPoint(ControllerParamters paramters) : base(paramters)
        {
            
        }


        [HttpPost("createPoll")]
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
