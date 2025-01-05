
namespace SurveyBasket_VerticalSlice.Features.Authentication.RevokeTokenCQ
{
    public class RevokeRefrshTokenEndPoint : BaseController
    {
        public RevokeRefrshTokenEndPoint(ControllerParamters controllerParamters) : base(controllerParamters)
        {
        }

        [HttpPost]
        public async Task<ActionResult> RevokeRefreshToken(RevokeRefreshTokenRequest request)
        {
            var result = await _Sender.Send(new RevokeTokenCommand(request.Token, request.RefreshToken));

            return result.IsSuccess ? Ok(result) : result.ToProblem(StatusCodes.Status400BadRequest);
        }
    }
}
