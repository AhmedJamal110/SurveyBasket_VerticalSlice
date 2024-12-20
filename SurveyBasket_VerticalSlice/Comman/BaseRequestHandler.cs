
namespace SurveyBasket_VerticalSlice.Comman
{
    public abstract class BaseRequestHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        protected readonly IMediator _mediator;
        protected readonly ISender _sender;
        protected readonly AutoMapper.IMapper _mapper;


        public BaseRequestHandler(RequestParameters parameters)
        {
            _mediator = parameters.Mediator;
            _sender = parameters.Sender;
            _mapper = parameters.Mapper;
        }

        public abstract Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);
  
    }
}
