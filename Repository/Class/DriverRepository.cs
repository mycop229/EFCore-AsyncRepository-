using Intership.Models;
using Intership.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Intership.Repository.Class
{
    public class DriverRepository : IDriverRepository<Driver>
    {
        private readonly ApplicationContext _db;

        public DriverRepository()
        {
            _db = new ApplicationContext();
        }
        public async Task<IEnumerable<Driver>> GetAll()
        {
            return await _db.Drivers
                            .Include(x => x.Car).ToListAsync();
        }

        public async Task<Driver> GetById(int id)
        {
            return await _db.Drivers
                            .Include(x => x.Car).SingleOrDefaultAsync(r => r.Id == id);
        }

        public async Task Create(Driver item)
        {
            if (item != null)
            {
                await _db.Drivers.AddAsync(item);
                await _db.SaveChangesAsync();
            }
        }

        public async Task Update(Driver item)
        {
            _db.Entry(item).State = EntityState.Modified;
            await _db.SaveChangesAsync();
        }

        public async Task<bool> Delete(int id)
        {
            var item = await _db.Drivers.FindAsync(id);
            if (item != null)
            {
                _db.Drivers.Remove(item);
                await _db.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<IEnumerable<Driver>> FindBySurnameToList(string surname)
        {
            return await _db.Drivers
                .Include(x => x.Car).Where(r => r.Surname == surname).ToListAsync();
        }

        public async Task<Driver> FindBySurnameFirstOrDefault(string surname)
        {
            return await _db.Drivers.Include(x => x.Car).FirstOrDefaultAsync(x => x.Surname == surname);
        }
    }
}
