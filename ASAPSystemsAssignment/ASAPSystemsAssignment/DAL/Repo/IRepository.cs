namespace ASAPSystemsAssignment.DAL.Repo
{
    public interface IRepository<T>where T : class
    {
       Task<List<T>> GetAll();
       Task<T> Get(int id);
       Task Add(T model);
       Task Edit(T model);
       Task Remove(T model);

    }
}
