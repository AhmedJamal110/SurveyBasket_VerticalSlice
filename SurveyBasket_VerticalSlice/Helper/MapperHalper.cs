using AutoMapper.QueryableExtensions;

namespace SurveyBasket_VerticalSlice.Helper
{
    public static class MapperHalper
    {
        public static AutoMapper.IMapper Mapper { get; set; }
       
        public static IEnumerable<TResult> MapperProjectTo<TResult>(this IQueryable source)
        {
            return source.ProjectTo<TResult>(Mapper.ConfigurationProvider);
        }
    
        public static TResult MapOne<TResult>(this object source)
        {
            return Mapper.Map<TResult>(source);
        }
    }
}
