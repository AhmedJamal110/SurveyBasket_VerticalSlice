using Microsoft.AspNetCore.Mvc;
using SurveyBasket_VerticalSlice.Abstractions;
using SurveyBasket_VerticalSlice.Comman;

namespace SurveyBasket_VerticalSlice.Features.Polls.GetAllPolls
{
    public class GetAllPollsEndPoint : BaseController
    {
        public GetAllPollsEndPoint(ControllerParamters controllerParamters) : base(controllerParamters)
        {
        }

        [HttpGet]
        public async Task<ActionResult> GetAllPolls()
        {
            var result = await _Sender.Send(new GetAllPollsQuery());

            return result.IsSuccess ? Ok(result.Value) : result.ToProblem(StatusCodes.Status404NotFound);
        }
             
    
    }
}
