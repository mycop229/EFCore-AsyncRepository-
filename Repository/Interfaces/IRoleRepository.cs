namespace Intership.Repository.Interfaces
{
    public interface IRoleRepository<Role> : IBaseRepository<Role>
    {
        Task<Role> GetByName(string name);
    }
}
