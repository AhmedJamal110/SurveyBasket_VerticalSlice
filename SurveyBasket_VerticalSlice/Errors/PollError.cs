namespace SurveyBasket_VerticalSlice.Errors
{
    public static class PollError
    {
        public static readonly Error PollNotFound
            = new("Poll.NotFound", "Poll not found");

        public static readonly Error PollDeplucated
          = new("Poll.PollIsAlreadyExsit", "Poll title is alredy Exist");


        public static readonly Error ErrorSavePoll
          = new("Poll.Add Poll", "Error While Saving Poll , try again ");
    }
}
