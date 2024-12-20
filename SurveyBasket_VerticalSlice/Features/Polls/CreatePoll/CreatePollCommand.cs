using MediatR;
using SurveyBasket.Abstractions;

namespace SurveyBasket_VerticalSlice.Features.Polls.CreatePoll
{
    public record CreatePollCommand(string Title,   string Summary, DateOnly StratsAT, DateOnly EndAt) 
            : IRequest<Result<CreatePollResponse>>;
    
}
