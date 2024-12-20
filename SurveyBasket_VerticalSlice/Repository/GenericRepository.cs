using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SurveyBasket_VerticalSlice.Domain.Entities;
using SurveyBasket_VerticalSlice.Persistence;
using System.Linq.Expressions;

namespace SurveyBasket_VerticalSlice.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext _context;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<T> AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            return entity;
        }

        public IQueryable<T> GetAllAsync()
        {
            return _context.Set<T>().Where(x => x.IsDeleted == false);
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _context.Set<T>()
                                           .AsNoTracking()
                                           .FirstOrDefaultAsync(x => x.Id == id && x.IsDeleted == false);
        }

        public async Task HardDelte(int id)
        {
            await _context.Set<T>().Where(x => x.Id == id).ExecuteDeleteAsync();
        }

        public async Task<bool> IsEntityExsit(Expression<Func<T, bool>> expression)
        {
            return await _context.Set<T>().AnyAsync(expression);
        }

        public async Task SoftDelte(int id)
        {
            await _context.Set<T>()
           .Where(x => x.Id == id)
           .ExecuteUpdateAsync(x => x.SetProperty(p => p.IsDeleted, true));
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }

        public void UpdateInclude(T entity, params string[] updatedProp)
        {
            var local = _context.Set<T>().Local.FirstOrDefault(x => x.Id == entity.Id);

            EntityEntry entityEntry;
            if (local is null)
            {
                entityEntry = _context.Entry(entity);
            }
            else
            {
                entityEntry = _context.ChangeTracker.Entries<BaseEntity>().FirstOrDefault(x => x.Entity.Id == entity.Id);
            }

            foreach (var prop in entityEntry.Properties)
            {
                if (updatedProp.Contains(prop.Metadata.Name))
                {
                    prop.CurrentValue = entity.GetType().GetProperty(prop.Metadata.Name).GetValue(entity);
                    prop.IsModified = true;
                }
            }

        }
    }
}

