using Microsoft.EntityFrameworkCore;
using MVC_XP.Model.Interfaces;

namespace MVC_XP.Infra
{
    public class MVCXPRepository : IRepository
    {
        private readonly MVCXPContext _context;

        public MVCXPRepository(MVCXPContext context)
        {
            _context = context;
        }

        public async Task AddAsync<T>(T entity) where T : class
        {
            await _context.AddAsync<T>(entity);
        }

        public async Task<int> CountAsync<T>() where T : class
        {
            return await _context.Set<T>().CountAsync();
        }

        public async Task DeleteAsync<T>(object id) where T : class
        {
            var entity = await GetByIdAsync<T>(id);
            if(entity != null)
            {
                _context.Remove(entity);
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync<T>() where T : class
        {
            return await Query<T>().ToListAsync();
        }

        public async Task<T?> GetByIdAsync<T>(object id) where T : class
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public IQueryable<T> Query<T>() where T : class
        {
            return _context.Set<T>().AsQueryable();
        }
        
        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task<List<T>> ToListAsync<T>(IQueryable<T> query)
        {
            return await query.ToListAsync();
        }

        public void Update<T>(T entity) where T : class
        {
            var entry = _context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                _context.Attach(entry);
            }
            entry.State = EntityState.Modified;
        }
    }
}
