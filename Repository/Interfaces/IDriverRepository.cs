namespace Intership.Repository.Interfaces
{
    public interface IDriverRepository<Driver> : IBaseRepository<Driver>
    {
        Task<IEnumerable<Driver>> FindBySurnameToList(string surname);
        Task<Driver> FindBySurnameFirstOrDefault(string surname);
    }
}
