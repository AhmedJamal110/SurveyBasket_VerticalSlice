
namespace SurveyBasket_VerticalSlice.Features.Authentication.Login
{
    public class LoginEndPoint : BaseController
    {
        public LoginEndPoint(ControllerParamters controllerParamters) : base(controllerParamters)
        {
        }

        [HttpPost]
        public async Task<ActionResult> Login([FromBody]LoginRequest request)
        {
           var result =   await _Sender.Send(new LoginCommand(request.Email, request.Password));
            return result.IsSuccess ?  Ok(result.Value) : result.ToProblem(StatusCodes.Status401Unauthorized);
        }
        
    }
}
