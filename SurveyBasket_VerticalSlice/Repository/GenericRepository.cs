
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

        public async Task<TDestination?> FirstAsync<TDestination>(Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> query = _context.Set<T>().AsNoTracking();
                
            return await  query.Where(predicate).ProjectToType<TDestination>().FirstOrDefaultAsync();
        }

        public Task<T?> FirstAsync(Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> query = _context.Set<T>().AsNoTracking();

            return query.Where(predicate).FirstOrDefaultAsync();

        }

        public IQueryable<T> GetAllAsync()
        {
            return _context.Set<T>().Where(x => x.IsDeleted == false).AsNoTracking();
        }
 

        public async Task<T?> FirstWithIncludeAsync(Expression<Func<T, bool>> predicate , Expression<Func<T, object>> IncludedProp)
        {
            IQueryable<T> query = _context.Set<T>().AsNoTracking();

            return await query.Include(IncludedProp).Where(predicate).FirstOrDefaultAsync();

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

        public Task Update(T entity)
        {
            _context.Set<T>().Update(entity);
            return Task.CompletedTask;
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

