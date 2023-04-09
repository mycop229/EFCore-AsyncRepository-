using Intership.Models;
using Intership.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Intership.Repository.Class
{
    public class RegistrationDataRepository : IRegistrationDataRepository<RegistrationData>
    {
        private readonly ApplicationContext _db;
        public RegistrationDataRepository()
        {
            this._db = new ApplicationContext();
        }
        public async Task<IEnumerable<RegistrationData>> GetAll()
        {
            return await _db.RegistrationDatas.ToListAsync();
        }

        public async Task<RegistrationData> GetById(int id)
        {
            return await _db.RegistrationDatas.SingleOrDefaultAsync(r => r.Id == id);
        }

        public async Task Create(RegistrationData item)
        {
            if (item != null)
            {
                await _db.RegistrationDatas.AddAsync(item);
                await _db.SaveChangesAsync();
            }
        }

        public async Task Update(RegistrationData item)
        {
            _db.Entry(item).State = EntityState.Modified;
            await _db.SaveChangesAsync();
        }

        public async Task<bool> Delete(int id)
        {
            var item = await _db.RegistrationDatas.FindAsync(id);
            if (item != null)
            {
                _db.RegistrationDatas.Remove(item);
                await _db.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<RegistrationData> GetByLoginAndPassword(string login, string password)
        {
            return await _db.RegistrationDatas.Where(x => x.Login == login)
                                              .Where(x => x.Password == password)
                                              .FirstOrDefaultAsync();
        }
    }
}
