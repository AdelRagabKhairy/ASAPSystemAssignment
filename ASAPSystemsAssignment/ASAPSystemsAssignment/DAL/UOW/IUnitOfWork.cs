using ASAPSystemsAssignment.DAL.Model;
using ASAPSystemsAssignment.DAL.Repo;

namespace ASAPSystemsAssignment.DAL.UOW
{
    public interface IUnitOfWork: IDisposable
    {
        IRepository<Product> Products { get; }
        
        Task<int> SaveAsync();
    }
}
