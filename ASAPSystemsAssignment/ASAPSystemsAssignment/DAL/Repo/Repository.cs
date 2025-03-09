
using ASAPSystemsAssignment.DAL.DbContainer;
using Microsoft.EntityFrameworkCore;

namespace ASAPSystemsAssignment.DAL.Repo
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;
        public Repository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        public async Task Add(T model)
        {
            await _dbSet.AddAsync(model);
        }

        public async Task Edit(T model)
        {
             _dbSet.Update(model);
        }

        public async Task<T> Get(int id)
        {
           return await _dbSet.FindAsync(id);
        }

        public async Task<List<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task Remove(T model)
        {
             _dbSet.Remove(model);
        }
    }
}
