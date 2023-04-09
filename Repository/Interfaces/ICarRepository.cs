namespace Intership.Repository.Interfaces
{
    public interface ICarRepository<Car> : IBaseRepository<Car>
    {
        Task<IEnumerable<Car>> FindByNumber(string number);
        Task<Car> FindByName(string name);
    }
}
