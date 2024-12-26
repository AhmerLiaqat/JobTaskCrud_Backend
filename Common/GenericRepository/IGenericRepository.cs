namespace JobTaskCrud.Common.GenericRepository
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(object id);
        Task<int> commitAsync();
        void Rollback();

    }
}
