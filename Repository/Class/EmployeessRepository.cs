using Intership.Models;
using Intership.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Intership.Repository.Class
{
    public class EmployeessRepository : IEmployeessRepository<Employeess>
    {
        private readonly ApplicationContext _db;
        public EmployeessRepository()
        {
            _db = new ApplicationContext();
        }
        public async Task<IEnumerable<Employeess>> GetAll()
        {
            return await _db.Employeesses
                            .Include(x => x.Role)
                            .Include(x => x.RegistrationData).ToListAsync();
        }
        public async Task<Employeess> GetById(int id)
        {
            return await _db.Employeesses
                            .Include(x => x.Role)
                            .Include(x => x.RegistrationData).SingleOrDefaultAsync(r => r.Id == id);
        }
        public async Task Create(Employeess item)
        {
            if (item != null)
            {
                await _db.Employeesses.AddAsync(item);
                await _db.SaveChangesAsync();
            }
        }
        public async Task Update(Employeess item)
        {
            _db.Entry(item).State = EntityState.Modified;
            await _db.SaveChangesAsync();
        }
        public async Task<bool> Delete(int id)
        {
            var item = await _db.Employeesses.FindAsync(id);
            if (item != null)
            {
                _db.Employeesses.Remove(item);
                await _db.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<Employeess> FindByRegistrationId(int id)
        {
            return await _db.Employeesses.Include(x => x.RegistrationData)
                                         .Include(x => x.Role)
                                         .Where(x => x.RoleId == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Employeess>> FindBySurname(string surname)
        {
            return await _db.Employeesses.Include(x => x.RegistrationData)
                                         .Include(x => x.Role)
                                         .Where(x => x.Surname == surname).ToListAsync();
        }

        public async Task<IEnumerable<Employeess>> FindByNumberPhone(string numberPhone)
        {
            return await _db.Employeesses.Include(x => x.RegistrationData)
                                         .Include(x => x.Role)
                                         .Where(x => x.NumberPhobne == numberPhone).ToListAsync();
        }
    }
}
