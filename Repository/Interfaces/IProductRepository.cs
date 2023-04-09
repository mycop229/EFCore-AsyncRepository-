namespace Intership.Repository.Interfaces
{
    public interface IProductRepository<Product> : IBaseRepository<Product>
    {
        Task<IEnumerable<Product>> GetByNameList(string name);
        Task<Product> GetByNameFirstOrDefault(string name);
    }
}
