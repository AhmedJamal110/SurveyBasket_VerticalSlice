
using SurveyBasket_VerticalSlice.Features.Polls.GetPollByID;
using SurveyBasket_VerticalSlice.Features.Polls.IsPollExist;

namespace SurveyBasket_VerticalSlice.Features.Polls.UpdatePoll
{
    public class UpdatePollCommandHandler : BaseRequestHandler<UpdatePollCommand , Result>
    {
        private readonly IGenericRepository<Poll> _pollReposatory;

        public UpdatePollCommandHandler(RequestParameters parameters
            , IGenericRepository<Poll> PollReposatory ) : base(parameters)
        {
            _pollReposatory = PollReposatory;
        }

        public override async Task<Result> Handle(UpdatePollCommand request, CancellationToken cancellationToken)
        {
            var pollResponse = await  _sender.Send(new GetPollByIdQuery(request.Id));
          //  var pollInDb = await _pollReposatory.GetByIdAsync(request.Id);
                if (pollResponse is null)
                        return Result.Failure<UpdatePollResponse>(PollError.PollNotFound);

            bool isExsit = await _sender.Send(new IsEntityExistQuery(poll => poll.Id != request.Id && poll.Title == request.Title));
            //bool isExsit = await _pollReposatory.IsEntityExsit(poll => poll.Id != request.Id && poll.Title == request.Title);
                if (isExsit)     
                        return Result.Failure<UpdatePollResponse>(PollError.PollDeplucated);

                  Poll pollInDb = pollResponse.Adapt<Poll>();

            pollInDb.Title = request.Title;
            pollInDb.Summary = request.Summary;


            await _pollReposatory.Update(request.Adapt<Poll>());

            return Result.Success();

        }
    }
}
