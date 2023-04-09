namespace Intership.Repository.Interfaces
{
    public interface IOrderRepository<Order> : IBaseRepository<Order>
    {
        Task<IEnumerable<Order>> GetByName(string name);
    }
}
