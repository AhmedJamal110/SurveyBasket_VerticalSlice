using Microsoft.AspNetCore.Mvc;
using SurveyBasket_VerticalSlice.Comman;

namespace SurveyBasket_VerticalSlice.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected IMediator _Mediator;
        protected ISender _Sender;
        public BaseController(ControllerParamters controllerParamters)
        {
            _Mediator = controllerParamters.Mediator;
            _Sender = controllerParamters.Sender;
        }
    }
}
