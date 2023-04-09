namespace Intership.Repository.Interfaces
{
    public interface IEmployeessRepository<Employeess> : IBaseRepository<Employeess>
    {
        Task <Employeess> FindByRegistrationId(int id);
        Task<IEnumerable<Employeess>> FindBySurname(string surname);
        Task<IEnumerable<Employeess>> FindByNumberPhone(string numberPhone);
    }
}
