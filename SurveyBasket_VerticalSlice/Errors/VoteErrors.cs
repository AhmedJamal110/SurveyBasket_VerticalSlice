namespace SurveyBasket_VerticalSlice.Errors;

public static class VoteErrors
{
    public static readonly Error DuplicatedVoted
         = new("Vote.Duplicated", "the user already voted before");
}
