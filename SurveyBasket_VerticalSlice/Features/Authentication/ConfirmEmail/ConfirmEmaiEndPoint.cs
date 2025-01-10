
namespace SurveyBasket_VerticalSlice.Features.Authentication.ConfirmEmail
{
    public class ConfirmEmaiEndPoint : BaseController
    {
        public ConfirmEmaiEndPoint(ControllerParamters controllerParamters) : base(controllerParamters)
        {
        }

        [HttpPost]
        public async Task<ActionResult> ConfirmEmail(ConfirmEmailRequest request)
        {
            var result = await _Sender.Send(new ConfirmEmailCommand(request.UserId, request.Code));
            return result.IsSuccess ? Ok() : result.ToProblem(StatusCodes.Status400BadRequest);
        }
    
    }
}
