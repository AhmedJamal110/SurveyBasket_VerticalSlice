namespace SurveyBasket_VerticalSlice.Helper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreatePollRequest, Poll>();
            CreateMap<CreatePollCommand, Poll>();
            CreateMap<Poll, CreatePollResponse>();
        }
    }
}
