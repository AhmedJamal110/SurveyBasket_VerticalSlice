
namespace SurveyBasket_VerticalSlice.Features.Authentication.Register
{
    public class RegisterEndPoint : BaseController
    {
        public RegisterEndPoint(ControllerParamters controllerParamters) : base(controllerParamters)
        {
        }

        [HttpPost]
        public async Task<ActionResult> Register(RegisterRequest request)
        {
           var result = await _Sender.Send(new RegisterCommand(request.FirstName, request.LastName, request.Email, request.Password));

            return result.IsSuccess ? Ok(result) : result.ToProblem(StatusCodes.Status400BadRequest);
        }
    }
}
