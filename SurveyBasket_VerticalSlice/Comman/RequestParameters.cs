namespace SurveyBasket_VerticalSlice.Comman
{
    public class RequestParameters
    {
        public IMediator Mediator { get; set; }
        public ISender Sender { get; set; }
        public AutoMapper.IMapper Mapper { get; set; }

        public RequestParameters(IMediator mediator , ISender sender , AutoMapper.IMapper mapper)
        {
            Mediator = mediator;
            Sender = sender;
            Mapper = mapper;
        }
    }
}
