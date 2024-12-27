
using JobTaskCrud.Context;
using Microsoft.EntityFrameworkCore;

namespace JobTaskCrud.Common.GenericRepository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        #region PROPERTIES
        protected readonly AppDbContext context;
        private readonly DbSet<T> _dbSet;
        #endregion

        #region CONSTRUCTOR
        public GenericRepository(AppDbContext context)
        {
            this.context = context;
            _dbSet = context.Set<T>();
        }
        #endregion

        #region FUNCTION

        public async Task<T> AddAsync(T entity)
        {
            await context.Set<T>().AddAsync(entity);

            return entity;
        }

        public Task<int> commitAsync()
        {
            return context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            context.Set<T>().Remove(entity);
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await context.Set<T>().ToListAsync();
        }
        public async Task<T> GetByIdAsync(object id)
        {
            return await context.Set<T>().FindAsync(id);
        }
        public async Task<T> GetByNameAsync(string name) 
        {
            return await context.Set<T>().FirstOrDefaultAsync(entity => EF.Property<string>(entity, "name") == name);
        }
        public void Rollback()
        {
            context.Dispose();
        }

        public async Task<T> UpdateAsync(T entity)
        {
            context.Set<T>().Update(entity);
            return entity;
        }
        #endregion
    }
}
