namespace SurveyBasket_VerticalSlice.Helper
{
    public class MappingConfigration : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Poll, CreatePollResponse>()
                    .Map(dis => dis.Id, src => src.Id);
        }
    }
}
