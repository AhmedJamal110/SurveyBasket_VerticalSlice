namespace SurveyBasket_VerticalSlice.Errors
{
    public static class QuestionError
    {
        public static readonly Error QuestionNotFound
            = new("Question.NotFound", "Question not found");

        public static readonly Error QuestionlDeplucated
          = new("Question.QuestionIsAlreadyExsit", "Question title is alredy Exist");


        public static readonly Error ErrorSaveQuestion
          = new("Question.Add Question", "Error While Saving Question , try again ");
    }
}
