namespace Intership.Repository.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task Create (T item);
        Task Update (T item);
        Task<bool> Delete (int id);
    }
}
