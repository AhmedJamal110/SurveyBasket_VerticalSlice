namespace SurveyBasket_VerticalSlice.Comman
{
    public class ControllerParamters
    {
        public ISender Sender { get; set; }
        public IMediator Mediator  { get; set; }

        public ControllerParamters(IMediator mediator , ISender sender)
        {
            Mediator = mediator;
            Sender = sender;
        }
    }
}
