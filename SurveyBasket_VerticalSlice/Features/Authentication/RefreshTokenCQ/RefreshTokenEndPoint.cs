
namespace SurveyBasket_VerticalSlice.Features.Authentication.RefreshTokenCQ
{
    public class RefreshTokenEndPoint : BaseController
    {
        public RefreshTokenEndPoint(ControllerParamters controllerParamters) : base(controllerParamters)
        {
        }

        [HttpPost]
        public async Task<ActionResult> RefreshToken(RefreshTokenRequest request)
        {
           var result = await  _Sender.Send(new CreateRefreshTokenCommand(request.Token, request.RefreshToken));

            return result.IsSuccess ? Ok(result.Value) : result.ToProblem(StatusCodes.Status400BadRequest);
        }
    }
}
