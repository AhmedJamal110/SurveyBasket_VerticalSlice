using SurveyBasket_VerticalSlice.Domain.Identity;
using SurveyBasket_VerticalSlice.Features.Authentication.Register;
using SurveyBasket_VerticalSlice.Features.Questions.CreateQuestion;

namespace SurveyBasket_VerticalSlice.Helper
{
    public class MappingConfigration : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {

            config.NewConfig<Poll, CreatePollResponse>()
                    .Map(dis => dis.Id, src => src.Id);


            config.NewConfig<RegisterCommand, ApplicationUser>()
                    .Map(dis => dis.UserName, src => src.Email);


            config.NewConfig<CreateQuestionCommand, Question>()
                    .Map(dis => dis.Content, src => src.Request.Content)
                   .Map(dis => dis.Answers, src => src.Request.Answers.Select(answer => new Answer { Content = answer }));
        }
    }
}
