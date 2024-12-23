using SurveyBasket_VerticalSlice.Domain.Entities;
using System.Linq.Expressions;

namespace SurveyBasket_VerticalSlice.Repository
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        IQueryable<T> GetAllAsync();
        Task<T?> GetByIdAsync(int id);
        Task<bool> IsEntityExsit(Expression<Func<T, bool>> expression);
        Task<T> AddAsync(T entity);
        Task Update(T entity);
        void UpdateInclude(T entity, params string[] updatedProp);
        Task HardDelte(int id);
        Task SoftDelte(int id);
    }
}
