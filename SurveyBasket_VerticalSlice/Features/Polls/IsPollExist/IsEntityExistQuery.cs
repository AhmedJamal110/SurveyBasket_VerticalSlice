namespace SurveyBasket_VerticalSlice.Features.Polls.IsPollExist
{
    public record IsEntityExistQuery(Expression<Func<Poll , bool>> predicate) : IRequest<bool>;
    
}
