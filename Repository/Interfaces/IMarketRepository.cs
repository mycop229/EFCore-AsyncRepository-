namespace Intership.Repository.Interfaces
{
    public interface IMarketRepository<Market> : IBaseRepository<Market>
    {
        Task<IEnumerable<Market>> GetByNameToList(string name);
        Task<Market> GetByNameFirstOrDefault(string name);
        Task<IEnumerable<Market>> GetByAddress(string name);
    }
}
