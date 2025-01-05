using SurveyBasket_VerticalSlice.Domain.Identity;
using SurveyBasket_VerticalSlice.Features.Authentication.Register;

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
            
        }
    }
}
