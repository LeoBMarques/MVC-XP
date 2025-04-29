namespace MVC_XP.Model.Interfaces
{
    public interface IRepository
    {
        Task AddAsync<T>(T entity) where T : class;
        Task<int> CountAsync<T>() where T : class;
        Task DeleteAsync<T>(object id) where T : class;
        Task<IEnumerable<T>> GetAllAsync<T>() where T : class;
        Task<T?> GetByIdAsync<T>(object id) where T : class;
        IQueryable<T> Query<T>() where T : class;
        Task<int> SaveChangesAsync();
        Task<List<T>> ToListAsync<T>(IQueryable<T> query);
        void Update<T>(T entity) where T : class;
    }
}
