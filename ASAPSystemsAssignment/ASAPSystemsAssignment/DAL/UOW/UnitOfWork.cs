using ASAPSystemsAssignment.DAL.DbContainer;
using ASAPSystemsAssignment.DAL.Model;
using ASAPSystemsAssignment.DAL.Repo;

namespace ASAPSystemsAssignment.DAL.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private  IRepository<Product> _products;
        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }
        public IRepository<Product> Products => _products ??= new Repository<Product>(_context);

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<int> SaveAsync()
        {
           return await _context.SaveChangesAsync();
            
        }
    }
}
