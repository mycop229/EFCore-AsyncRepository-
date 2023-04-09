namespace Intership.Repository.Interfaces
{
    public interface IRegistrationDataRepository<RegistrationData> : IBaseRepository<RegistrationData>
    {
        Task <RegistrationData> GetByLoginAndPassword(string login, string password);
    }
}
