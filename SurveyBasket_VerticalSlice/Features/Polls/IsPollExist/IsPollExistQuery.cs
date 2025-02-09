namespace SurveyBasket_VerticalSlice.Features.Polls.IsPollExist
{
    public record IsPollExistQuery(Expression<Func<Poll , bool>> predicate) : IRequest<bool>;
    
}
